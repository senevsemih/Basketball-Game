using UnityEngine;

namespace _Game_.Test
{
    public class ShipMotor
    {
        private readonly IShipInput _shipInput;
        private readonly Transform _transformToMove;
        private readonly ShipSettings _shipSettings;

        public ShipMotor(
            IShipInput shipInput,
            Transform transformToMove,
            ShipSettings shipSettings)
        {
            _shipInput = shipInput;
            _transformToMove = transformToMove;
            _shipSettings = shipSettings;
        }

        public void Tick()
        {
            _transformToMove.Rotate(Vector3.up * _shipInput.Rotation * Time.deltaTime * _shipSettings.TurnSpeed);
            _transformToMove.position += _transformToMove.forward * _shipInput.Thrust * Time.deltaTime * _shipSettings.MoveSpeed;
        }
    }
}