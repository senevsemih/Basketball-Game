using UnityEngine;

namespace _Game_.Scripts.Character.Other.Interaction
{
    public class RadarInteraction : MonoBehaviour
    {
        private CharacterEvents _events;

        private void Awake() => _events = GetComponentInParent<CharacterEvents>();

        public void Selected() => _events.OnRadarSelectActive?.Invoke();

        public void Unselected() => _events.OnRadarSelectInactive?.Invoke();
    }
}