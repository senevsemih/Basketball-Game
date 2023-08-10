using _Game_.Scripts.Court.Rim.Hoop.Interface;
using UnityEngine;
using UnityEngine.Events;

namespace _Game_.Scripts.Court.Rim.Hoop
{
    public class HoopEvents : MonoBehaviour
    {
        // Interaction
        [HideInInspector] public UnityEvent<IHoopInteraction> onInteractedWithBall = new();
    }
}