using _Game_.Scripts.Ball.Interface;
using _Game_.Scripts.Court.Rim.Hoop.Interface;
using UnityEngine;

namespace _Game_.Scripts.Court.Rim.Hoop
{
    public class HoopInteraction : MonoBehaviour, IHoopInteraction
    {
        private HoopEvents _events;

        private void Awake() => _events = GetComponentInParent<HoopEvents>();

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IBall ball))
            {
                _events.onInteractedWithBall?.Invoke(this);
            }
        }
    }
}