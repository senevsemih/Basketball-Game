using _Game_.Scripts.Ball.Enum;
using _Game_.Scripts.Character.Base;
using _Game_.Scripts.Character.Components;
using _Game_.Scripts.Character.Data;
using _Game_.Scripts.Character.Enums;
using _Game_.Scripts.Managers;

namespace _Game_.Scripts.Character.Behaviours
{
    public class ShotBehaviour : BehaviourBase
    {
        public ShotBehaviour(
            CharacterData data,
            CharacterEvents events) : base(data, events)
        {
            Events.onShootKeyTriggered.AddListener(Execute);
        }

        public override void Activate()
        {
            base.Activate();
            Events.onAnimationStateUpdate?.Invoke(CharacterAnimationState.Shot);
        }

        public override void Execute()
        {
            base.Execute();
            CharacterEvents.OnLaunchBall?.Invoke(
                Data.BallPosition,
                GameManager.Instance.RimController.Position,
                BallLaunchType.Shot);

            Events.onBehaviourExecuted?.Invoke();
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            Events.onShootKeyTriggered.RemoveListener(Execute);
        }
    }
}