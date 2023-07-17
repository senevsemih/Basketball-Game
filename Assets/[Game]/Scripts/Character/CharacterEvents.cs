using _Game_.Scripts.Character.Data;
using _Game_.Scripts.Character.Enums;
using UnityEngine;
using UnityEngine.Events;

namespace _Game_.Scripts.Character
{
    public class CharacterEvents : MonoBehaviour
    {
        [HideInInspector] public UnityEvent<CharacterData> OnInitialized = new();
        
        // Animation Key
        [HideInInspector] public UnityEvent OnPassKeyTriggered = new();
        [HideInInspector] public UnityEvent OnShootKeyTriggered = new();

        // Behaviour
        // [HideInInspector] public UnityEvent OnShot = new();
        // [HideInInspector] public UnityEvent OnPass = new();
        [HideInInspector] public UnityEvent OnCaught = new();

        // State
        [HideInInspector] public UnityEvent<CharacterAnimationState> OnAnimationStateUpdate = new();
        
        // Movement
        [HideInInspector] public UnityEvent OnMovementActivated = new();
        [HideInInspector] public UnityEvent OnMovementInactivated = new();
        
        // Graphic
        [HideInInspector] public UnityEvent OnRadarSelectActive = new UnityEvent();
        [HideInInspector] public UnityEvent OnRadarSelectInactive = new UnityEvent();
    }
}