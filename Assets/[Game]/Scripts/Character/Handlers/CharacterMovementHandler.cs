using _Game_.Scripts.Character.Components;
using _Game_.Scripts.Character.Data;
using _Game_.Scripts.Character.Interfaces;
using _Game_.Scripts.Managers;
using UnityEngine;

namespace _Game_.Scripts.Character.Handlers
{
    public class CharacterMovementHandler : ICharacterHandler
    {
        private readonly CharacterData _data;
        private readonly CharacterEvents _events;

        private readonly Joystick _joystick;
        private readonly GameManager _gameManager;

        private Vector3 _inputDirection;

        public CharacterMovementHandler(
            CharacterData data,
            CharacterEvents events)
        {
            _data = data;
            _events = events;

            _joystick = Joystick.Instance;
            _gameManager = GameManager.Instance;

            _events.onMovementActivated.AddListener(OnMovementActivated);
            _events.onMovementInactivated.AddListener(OnMovementInactivated);
        }

        public void Tick()
        {
            if (!_data.IsMovementActive) return;

            GetInputDirection();
            Rotate();
            RimLook();
        }

        public void FixedTick()
        {
            if (!_data.IsMovementActive) return;

            Move();
        }

        public void OnDestroy()
        {
            _events.onMovementActivated.RemoveListener(OnMovementActivated);
            _events.onMovementInactivated.RemoveListener(OnMovementInactivated);
        }

        private void OnMovementActivated() => _data.IsMovementActive = true;
        private void OnMovementInactivated() => _data.IsMovementActive = false;

        private void GetInputDirection()
        {
            _inputDirection = _joystick.Direction;

            var directionMagnitude = _inputDirection.magnitude;
            if (directionMagnitude > 0)
            {
                _data.LastDirection = _inputDirection;
            }
        }

        private void Move()
        {
            _data.Rigidbody.velocity = _inputDirection * _data.Config.MoveSpeed;
            _data.VelocityMagnitude = _data.Rigidbody.velocity.magnitude;
        }

        private void Rotate()
        {
            var cRotation = _data.Transform.rotation;
            var target = _data.Transform.position + _inputDirection;

            Transform t2;
            (t2 = _data.Transform).LookAt(target);
            var tRotation = t2.rotation;

            _data.Transform.rotation = Quaternion.Lerp(
                cRotation,
                tRotation,
                _data.Config.RotateSpeed * Time.deltaTime);
        }

        private void RimLook()
        {
            var hoopPosition = _gameManager.RimController.Position;

            var dirFromAtoB = (hoopPosition - _data.Transform.position).normalized;
            var dotProd = Vector3.Dot(dirFromAtoB, _data.Transform.forward);

            _data.IsLookingToRim = dotProd > _data.Config.RimDotValue;
        }
    }
}