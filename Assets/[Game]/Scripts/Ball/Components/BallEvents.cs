using _Game_.Scripts.Ball.Data;
using UnityEngine;
using UnityEngine.Events;

namespace _Game_.Scripts.Ball.Components
{
    public class BallEvents : MonoBehaviour
    {
        [HideInInspector] public UnityEvent<BallData> onInitialized = new();
        [HideInInspector] public UnityEvent onLaunch = new();

        // Graphic
        [HideInInspector] public UnityEvent onActivated = new();
        [HideInInspector] public UnityEvent onInactivated = new();
    }
}