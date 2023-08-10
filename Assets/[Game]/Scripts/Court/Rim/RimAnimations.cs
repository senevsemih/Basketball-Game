using System.Collections;
using UnityEngine;

namespace _Game_.Scripts.Court.Rim
{
    public class RimAnimations : MonoBehaviour
    {
        private RimEvents _events;

        private Animator _animator;
        private Coroutine _animationRoutine;

        private bool _isAnimationPlaying;

        private static readonly int Shake = Animator.StringToHash("Interaction");

        private void Awake()
        {
            _events = GetComponentInParent<RimEvents>();
            _animator = GetComponent<Animator>();
        }

        private void OnEnable() => _events.onInteractedWithBall.AddListener(OnInteractedWithBall);
        private void OnDisable() => _events.onInteractedWithBall.RemoveListener(OnInteractedWithBall);

        private void OnInteractedWithBall() => AnimationChangeTo(Shake);

        private void AnimationChangeTo(int animationName)
        {
            if (_isAnimationPlaying) return;
            _animationRoutine = StartCoroutine(AnimationRoutine(animationName));
        }

        private IEnumerator AnimationRoutine(int animationName)
        {
            _animator.SetTrigger(animationName);
            _isAnimationPlaying = true;

            float counter = 0;
            var waitTime = _animator.GetCurrentAnimatorStateInfo(0).length;

            while (counter < waitTime)
            {
                counter += Time.deltaTime;
                yield return null;
            }

            _isAnimationPlaying = false;
        }

        private void OnDestroy()
        {
            if (_animationRoutine != null)
            {
                StopCoroutine(_animationRoutine);
            }
        }
    }
}