using _Game_.Scripts.Ball.Base;
using _Game_.Scripts.Ball.Components;
using _Game_.Scripts.Ball.Data;
using DG.Tweening;
using UnityEngine;

namespace _Game_.Scripts.Ball.Behaviours
{
    public class BallShotBehaviour : BallBehaviourBase
    {
        private const int JUMP_NUMBER = 1;
        private readonly string _jumpTweenID;

        public BallShotBehaviour(
            BallData data,
            BallEvents events) : base(data, events)
        {
            _jumpTweenID = "BallJumpTweenID";
        }

        public override void Activate()
        {
            base.Activate();
            Execute();
        }

        public override void Execute()
        {
            base.Execute();

            var jumpPosition = TargetPositionWithDeflection();
            var jumpPower = Random.Range(Config.ShotHeightRange.x, Config.ShotHeightRange.y);

            Data.Rigidbody.DOJump(
                    jumpPosition,
                    jumpPower,
                    JUMP_NUMBER,
                    Config.ShotDuration)
                .SetEase(Ease.Linear)
                .SetId(_jumpTweenID);
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            KillTween();
        }

        private void KillTween() => DOTween.Kill(_jumpTweenID);
    }
}