using _Game_.Scripts.Ball.Enum;
using _Game_.Scripts.Character.Base;
using _Game_.Scripts.Character.Components;
using _Game_.Scripts.Character.Data;
using _Game_.Scripts.Character.Enums;

namespace _Game_.Scripts.Character.Behaviours
{
    public class PassBehaviour : BehaviourBase
    {
        public PassBehaviour(
            CharacterData data,
            CharacterEvents events) : base(data, events)
        {
            Events.onPassKeyTriggered.AddListener(Execute);
        }

        public override void Activate()
        {
            base.Activate();
            Events.onAnimationStateUpdate?.Invoke(CharacterAnimationState.RunPass);
        }

        public override void Execute()
        {
            base.Execute();
            CharacterEvents.OnLaunchBall?.Invoke(
                Data.BallPosition,
                Data.ForwardDirection,
                BallLaunchType.Pass);

            Events.onBehaviourExecuted?.Invoke();
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            Events.onPassKeyTriggered.RemoveListener(Execute);
        }
    }
}