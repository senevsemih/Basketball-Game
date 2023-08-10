using UnityEngine;

namespace _Game_.Scripts.Ball.Components
{
    public class BallGraphic : MonoBehaviour
    {
        [SerializeField] private GameObject ballRenderer;
        private BallEvents _events;

        private void Awake() => _events = GetComponentInParent<BallEvents>();

        private void OnEnable()
        {
            _events.onActivated.AddListener(OnActivated);
            _events.onInactivated.AddListener(OnInactivated);
        }

        private void OnDisable()
        {
            _events.onActivated.RemoveListener(OnActivated);
            _events.onInactivated.RemoveListener(OnInactivated);
        }

        private void OnActivated() => SetGraphic(true);
        private void OnInactivated() => SetGraphic(false);

        private void SetGraphic(bool value) => ballRenderer.SetActive(value);
    }
}