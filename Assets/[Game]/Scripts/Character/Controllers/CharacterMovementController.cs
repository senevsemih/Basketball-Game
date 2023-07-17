using System;
using _Game_.Scripts.Character.Data;
using _Game_.Scripts.Character.Enums;
using UnityEngine;

namespace _Game_.Scripts.Character.Controllers
{
    public class CharacterMovementController : MonoBehaviour
    {
        private CharacterData _data;
        private CharacterEvents _events;

        private Rigidbody _rigidbody;
        public VariableJoystick _joystick;

        private Vector3 _inputDirection;

        private void Awake()
        {
            _events = GetComponent<CharacterEvents>();
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {
            _events.OnInitialized.AddListener(OnInitialized);
            _events.OnMovementActivated.AddListener(OnMovementActivated);
            _events.OnMovementInactivated.AddListener(OnMovementInactivated);
        }

        private void OnDisable()
        {
            _events.OnInitialized.RemoveListener(OnInitialized);
            _events.OnMovementActivated.RemoveListener(OnMovementActivated);
            _events.OnMovementInactivated.RemoveListener(OnMovementInactivated);
        }

        private void OnInitialized(CharacterData data) => _data = data;

        private void OnMovementActivated() => _data.IsMovementActive = true;

        private void OnMovementInactivated() => _data.IsMovementActive = false;

        private void Update()
        {
            if (!_data.IsMovementActive) return;

            GetInputDirection();
        }

        private void FixedUpdate()
        {
            if (!_data.IsMovementActive) return;

            Move();
            Rotate();
        }

        private void GetInputDirection() => _inputDirection = _joystick.Direction;

        private void Move()
        {
            _rigidbody.velocity = _inputDirection * _data.Config.MoveSpeed;
            var velocityMagnitude = _rigidbody.velocity.magnitude;

            _events.OnAnimationStateUpdate?.Invoke(velocityMagnitude < _data.Config.MoveThreshold
                ? CharacterAnimationState.Dribble
                : CharacterAnimationState.RunDribble);
        }

        private void Rotate()
        {
            var rotation = _rigidbody.rotation;
            var targetRotation = _rigidbody.position + _inputDirection;

            Transform t2;
            (t2 = transform).LookAt(targetRotation);

            var cRotation = t2.rotation;
            var nRotation = cRotation;
            cRotation = rotation;

            t2.rotation = cRotation;
            _rigidbody.rotation = Quaternion.Slerp(cRotation, nRotation, _data.Config.RotateSpeed * Time.deltaTime);
        }
    }
}