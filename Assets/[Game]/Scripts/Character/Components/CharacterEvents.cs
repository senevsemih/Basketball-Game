using _Game_.Scripts.Ball.Enum;
using _Game_.Scripts.Character.Data;
using _Game_.Scripts.Character.Enums;
using _Game_.Scripts.Court.Area.Enums;
using UnityEngine;
using UnityEngine.Events;

namespace _Game_.Scripts.Character.Components
{
    public class CharacterEvents : MonoBehaviour
    {
        [HideInInspector] public UnityEvent<CharacterData> onInitialized = new();

        [HideInInspector] public UnityEvent onCaught = new();
        [HideInInspector] public UnityEvent onBallReleased = new();

        [HideInInspector] public UnityEvent onBehaviourExecuted = new();

        // Animation Key
        [HideInInspector] public UnityEvent onPassKeyTriggered = new();
        [HideInInspector] public UnityEvent onShootKeyTriggered = new();

        // State
        [HideInInspector] public UnityEvent<CharacterAnimationState> onAnimationStateUpdate = new();

        // Movement
        [HideInInspector] public UnityEvent onMovementActivated = new();
        [HideInInspector] public UnityEvent onMovementInactivated = new();

        // Behaviours --GLOBAL-- 
        public static readonly UnityEvent OnCaughtBall = new();
        public static readonly UnityEvent<CourtAreasTypes> OnCourtAreaUpdated = new();
        public static readonly UnityEvent<Vector3, Vector3, BallLaunchType> OnLaunchBall = new();
    }
}