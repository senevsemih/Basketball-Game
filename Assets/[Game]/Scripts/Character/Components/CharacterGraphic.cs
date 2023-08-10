using _Game_.Scripts.Character.Data;
using UnityEngine;

namespace _Game_.Scripts.Character.Components
{
    public class CharacterGraphic : MonoBehaviour
    {
        private CharacterData _data;
        private CharacterEvents _events;

        private void Awake() => _events = GetComponentInParent<CharacterEvents>();

        private void OnEnable()
        {
            _events.onInitialized.AddListener(OnInitialized);

            _events.onCaught.AddListener(OnCaught);
            _events.onPassKeyTriggered.AddListener(OnPass);
            _events.onShootKeyTriggered.AddListener(OnShot);
        }

        private void OnDisable()
        {
            _events.onInitialized.RemoveListener(OnInitialized);

            _events.onCaught.RemoveListener(OnCaught);
            _events.onPassKeyTriggered.RemoveListener(OnPass);
            _events.onShootKeyTriggered.RemoveListener(OnShot);
        }

        private void OnInitialized(CharacterData data) => _data = data;

        private void OnPass() => SetBallGraphic(false);
        private void OnShot() => SetBallGraphic(false);
        private void OnCaught() => SetBallGraphic(true);

        private void SetBallGraphic(bool value) => _data.BallGraphic.SetActive(value);
    }
}