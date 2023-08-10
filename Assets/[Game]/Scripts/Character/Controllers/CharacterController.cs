using _Game_.Scripts.Character.Components;
using _Game_.Scripts.Character.Data;
using _Game_.Scripts.Character.Handlers;
using _Game_.Scripts.Character.Interfaces;
using _Game_.Scripts.Interfaces;
using _Game_.Scripts.Other;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Game_.Scripts.Character.Controllers
{
    [RequireComponent(typeof(Rigidbody))]
    public class CharacterController : MonoBehaviour, ITarget
    {
        public CharacterData data;

        private CharacterEvents _events;

        private ICharacterHandler _movementHandler;
        private ICharacterHandler _behaviourHandler;

        public Vector3 Position => data.Transform.position;

        private void Awake()
        {
            data.Transform = transform;
            data.Rigidbody = GetComponent<Rigidbody>();

            _events = GetComponent<CharacterEvents>();
        }

        private async void OnEnable()
        {
            _events.onCaught.AddListener(CaughtBall);

            await UniTask.WaitUntil(() => Joystick.Instance);

            Joystick.Instance.onInputUp.AddListener(OnInputUp);
            Joystick.Instance.onInputDown.AddListener(OnInputDown);
        }

        private void OnDisable()
        {
            _events.onCaught.RemoveListener(CaughtBall);

            if (Joystick.Instance != null)
            {
                Joystick.Instance.onInputUp.RemoveListener(OnInputUp);
                Joystick.Instance.onInputDown.RemoveListener(OnInputDown);
            }
        }

        private void Start()
        {
            ControllersSetup();
            CaughtBall();

            _events.onInitialized?.Invoke(data);
        }

        private void Update() => _movementHandler.Tick();
        private void FixedUpdate() => _movementHandler.FixedTick();

        private void ControllersSetup()
        {
            _movementHandler = new CharacterMovementHandler(data, _events);
            _behaviourHandler = new CharacterBehaviourHandler(data, _events);
        }

        private void CaughtBall()
        {
            data.HasBall = true;
            _events.onMovementActivated?.Invoke();

            CharacterEvents.OnCaughtBall?.Invoke();
            CharacterEvents.OnCourtAreaUpdated?.Invoke(data.CurrentCourtAreaType);

            ObjectFollower.OnTargetChanged?.Invoke(this);
        }

        private void OnInputUp()
        {
            data.Rigidbody.isKinematic = true;

            data.ForwardDirection = transform.forward;
            _events.onBallReleased?.Invoke();
        }

        private void OnInputDown()
        {
            data.Rigidbody.isKinematic = false;
        }

        public void OnDestroy()
        {
            _movementHandler.OnDestroy();
            _behaviourHandler.OnDestroy();
        }
    }
}