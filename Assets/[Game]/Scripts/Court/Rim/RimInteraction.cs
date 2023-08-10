using _Game_.Scripts.Ball.Interface;
using UnityEngine;

namespace _Game_.Scripts.Court.Rim
{
    public class RimInteraction : MonoBehaviour
    {
        private RimEvents _events;

        private void Awake() => _events = GetComponentInParent<RimEvents>();

        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.TryGetComponent(out IBall ball))
            {
                _events.onInteractedWithBall?.Invoke();
            }
        }
    }
}