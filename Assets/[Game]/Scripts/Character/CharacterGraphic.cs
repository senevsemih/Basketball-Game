using UnityEngine;

namespace _Game_.Scripts.Character
{
    public class CharacterGraphic : MonoBehaviour
    {
        [SerializeField] private GameObject BallGraphic;
        [SerializeField] private GameObject RadarIndicator;
        private CharacterEvents _events;

        private void Awake() => _events = GetComponentInParent<CharacterEvents>();

        private void Start() => SetRadarIndicator(false);

        private void OnEnable()
        {
            _events.OnPassKeyTriggered.AddListener(OnPass);
            _events.OnShootKeyTriggered.AddListener(OnShot);
            _events.OnCaught.AddListener(OnCaught);

            _events.OnRadarSelectActive.AddListener(OnRadarSelectActive);
            _events.OnRadarSelectInactive.AddListener(OnRadarSelectInactive);
        }

        private void OnDisable()
        {
            _events.OnPassKeyTriggered.RemoveListener(OnPass);
            _events.OnShootKeyTriggered.RemoveListener(OnShot);
            _events.OnCaught.RemoveListener(OnCaught);

            _events.OnRadarSelectActive.RemoveListener(OnRadarSelectActive);
            _events.OnRadarSelectInactive.RemoveListener(OnRadarSelectInactive);
        }

        private void OnPass() => SetBallGraphic(false);

        private void OnShot() => SetBallGraphic(false);

        private void OnCaught() => SetBallGraphic(true);

        private void OnRadarSelectActive() => SetRadarIndicator(true);
        private void OnRadarSelectInactive() => SetRadarIndicator(false);

        private void SetBallGraphic(bool value) => BallGraphic.SetActive(value);
        private void SetRadarIndicator(bool value) => RadarIndicator.SetActive(value);
    }
}