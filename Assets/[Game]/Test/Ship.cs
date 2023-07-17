using UnityEngine;

namespace _Game_.Test
{
    public class Ship : MonoBehaviour
    {
        [SerializeField] private ShipSettings ShipSettings;

        private IShipInput _shipInput;
        private ShipMotor _shipMotor;

        private void Awake()
        {
            _shipInput = ShipSettings.UseAi ? new AIInput() : new ControllerInput();
            _shipMotor = new ShipMotor(_shipInput, transform, ShipSettings);
        }

        private void Update()
        {
            _shipInput.ReadInput();
            _shipMotor.Tick();
        }
    }
}