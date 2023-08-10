using System;
using _Game_.Scripts.Character.Data;
using _Game_.Scripts.Character.Enums;
using UnityEngine;

namespace _Game_.Scripts.Character.Components
{
    public class CharacterAnimations : MonoBehaviour
    {
        private static readonly int Run = Animator.StringToHash("Run");
        private static readonly int Idle = Animator.StringToHash("Idle");
        private static readonly int Dribble = Animator.StringToHash("Dribble");
        private static readonly int RunDribble = Animator.StringToHash("RunDribble");
        private static readonly int RunPass = Animator.StringToHash("RunPass");
        private static readonly int Shot = Animator.StringToHash("Shot");

        private Animator _animator;

        private CharacterData _data;
        private CharacterEvents _events;
        private CharacterAnimationState _currentState;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _events = GetComponentInParent<CharacterEvents>();
        }

        private void OnEnable()
        {
            _events.onInitialized.AddListener(OnInitialized);
            _events.onAnimationStateUpdate.AddListener(AnimationChangeTo);
        }

        private void OnDisable()
        {
            _events.onInitialized.RemoveListener(OnInitialized);
            _events.onAnimationStateUpdate.RemoveListener(AnimationChangeTo);
        }

        private void Update() => UpdateMovementAnimation();

        private void OnInitialized(CharacterData data) => _data = data;

        private void AnimationChangeTo(CharacterAnimationState newState)
        {
            if (_currentState == newState) return;
            switch (newState)
            {
                case CharacterAnimationState.Idle:
                    _animator.SetTrigger(Idle);
                    break;
                case CharacterAnimationState.Run:
                    _animator.SetTrigger(Run);
                    break;
                case CharacterAnimationState.Dribble:
                    _animator.SetTrigger(Dribble);
                    break;
                case CharacterAnimationState.RunDribble:
                    _animator.SetTrigger(RunDribble);
                    break;
                case CharacterAnimationState.RunPass:
                    _animator.SetTrigger(RunPass);
                    break;
                case CharacterAnimationState.Shot:
                    _animator.SetTrigger(Shot);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
            }

            _currentState = newState;
        }

        private void UpdateMovementAnimation()
        {
            if (_data.IsBehaviourExecuting) return;
            if (_data.HasBall)
            {
                _events.onAnimationStateUpdate?.Invoke(_data.VelocityMagnitude < _data.Config.MoveThreshold
                    ? CharacterAnimationState.Dribble
                    : CharacterAnimationState.RunDribble);
            }
            else
            {
                _events.onAnimationStateUpdate?.Invoke(_data.VelocityMagnitude < _data.Config.MoveThreshold
                    ? CharacterAnimationState.Idle
                    : CharacterAnimationState.Run);
            }
        }
    }
}