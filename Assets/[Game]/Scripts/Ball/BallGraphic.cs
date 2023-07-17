using UnityEngine;

namespace _Game_.Scripts.Ball
{
    public class BallGraphic : MonoBehaviour
    {
        [SerializeField] private GameObject Graphic;

        private BallEvents _events;

        private void Awake() => _events = GetComponentInParent<BallEvents>();

        private void OnEnable()
        {
            _events.OnBallActivated.AddListener(OnBallActivated);
            _events.OnBallInactivated.AddListener(OnBallInactivated);
        }

        private void OnDisable()
        {
            _events.OnBallActivated.RemoveListener(OnBallActivated);
            _events.OnBallInactivated.RemoveListener(OnBallInactivated);
        }

        private void OnBallActivated() => SetGraphic(true);

        private void OnBallInactivated() => SetGraphic(false);

        private void SetGraphic(bool value) => Graphic.SetActive(value);
    }
}