using _Game_.Scripts.Ball.Components;
using _Game_.Scripts.Ball.Data;
using _Game_.Scripts.Ball.Handlers;
using _Game_.Scripts.Ball.Interface;
using _Game_.Scripts.Character.Components;
using _Game_.Scripts.Interfaces;
using _Game_.Scripts.Other;
using UnityEngine;

namespace _Game_.Scripts.Ball.Controllers
{
    [RequireComponent(typeof(Rigidbody))]
    public class BallController : MonoBehaviour, IBall, ITarget
    {
        public BallData data;

        private BallEvents _events;
        private IBallHandler _behaviourHandler;

        public Vector3 Position => transform.position;

        private void Awake()
        {
            data.Transform = transform;
            data.Rigidbody = GetComponent<Rigidbody>();

            _events = GetComponent<BallEvents>();
        }

        private void OnEnable()
        {
            _events.onLaunch.AddListener(OnLaunch);
            CharacterEvents.OnCaughtBall.AddListener(OnCharacterCaughtBall);
        }

        private void OnDisable()
        {
            _events.onLaunch.RemoveListener(OnLaunch);
            CharacterEvents.OnCaughtBall.RemoveListener(OnCharacterCaughtBall);
        }

        private void Start()
        {
            _behaviourHandler = new BallBehaviourHandler(data, _events);
            _events.onInitialized?.Invoke(data);
        }

        private void OnLaunch()
        {
            _events.onActivated?.Invoke();
            ObjectFollower.OnTargetChanged?.Invoke(this);
        }

        private void OnCharacterCaughtBall()
        {
            data.Rigidbody.isKinematic = true;
            _events.onInactivated?.Invoke();
        }

        private void OnDestroy() => _behaviourHandler.OnDestroy();
    }
}