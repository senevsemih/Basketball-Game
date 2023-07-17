using UnityEngine;
using UnityEngine.Events;

namespace _Game_.Scripts.Ball
{
    public class BallEvents : MonoBehaviour
    {
        [HideInInspector] public UnityEvent OnBallActivated = new();
        [HideInInspector] public UnityEvent OnBallInactivated = new();
    }
}