using _Game_.Scripts.Character.Data;
using _Game_.Scripts.Character.Enums;

namespace _Game_.Scripts.Character.Behaviours
{
    public class CharacterShootBehaviour : CharacterBehaviourBase
    {
        public CharacterShootBehaviour(
            CharacterData data,
            CharacterEvents events) : base(data, events)
        {
            Events.OnShootKeyTriggered.AddListener(Execute);
        }

        public override void Activate()
        {
            base.Activate();
            Events.OnAnimationStateUpdate?.Invoke(CharacterAnimationState.Shot);
        }

        public override void Execute()
        {
            base.Execute();
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            Events.OnShootKeyTriggered.RemoveListener(Execute);
        }
    }
}