using _Game_.Scripts.Ball.Interface;
using _Game_.Scripts.Character.Data;
using _Game_.Scripts.Court.Area.Enums;
using _Game_.Scripts.Court.Area.Interface;
using UnityEngine;

namespace _Game_.Scripts.Character.Components
{
    public class CharacterInteractions : MonoBehaviour
    {
        private CharacterData _data;
        private CharacterEvents _events;

        private void Awake() => _events = GetComponentInParent<CharacterEvents>();
        private void OnEnable() => _events.onInitialized.AddListener(OnInitialized);
        private void OnDisable() => _events.onInitialized.RemoveListener(OnInitialized);

        private void OnInitialized(CharacterData data) => _data = data;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IBall ball) && !_data.HasBall)
            {
                _events.onCaught?.Invoke();
            }

            if (other.TryGetComponent(out IArea area))
            {
                _data.CurrentCourtAreaType = area.CourtAreaType;
                CharacterEvents.OnCourtAreaUpdated?.Invoke(_data.CurrentCourtAreaType);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out IArea area))
            {
                if (area.CourtAreaType == CourtAreasTypes.ShotArea)
                {
                    _data.CurrentCourtAreaType = CourtAreasTypes.PassArea;
                    CharacterEvents.OnCourtAreaUpdated?.Invoke(_data.CurrentCourtAreaType);
                }
            }
        }
    }
}