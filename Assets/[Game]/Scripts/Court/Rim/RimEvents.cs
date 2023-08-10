using UnityEngine;
using UnityEngine.Events;

namespace _Game_.Scripts.Court.Rim
{
    public class RimEvents : MonoBehaviour
    {
        // Interaction
        [HideInInspector] public UnityEvent onInteractedWithBall = new();
    }
}