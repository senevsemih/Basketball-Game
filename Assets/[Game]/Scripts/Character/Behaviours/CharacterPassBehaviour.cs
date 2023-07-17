using _Game_.Scripts.Character.Data;
using _Game_.Scripts.Character.Enums;

namespace _Game_.Scripts.Character.Behaviours
{
    public class CharacterPassBehaviour : CharacterBehaviourBase
    {
        public CharacterPassBehaviour(
            CharacterData data,
            CharacterEvents events) : base(data, events)
        {
            Events.OnPassKeyTriggered.AddListener(Execute);
        }

        public override void Activate()
        {
            base.Activate();
            Events.OnAnimationStateUpdate?.Invoke(CharacterAnimationState.RunPass);
        }

        public override void Execute()
        {
            base.Execute();

            // Radarda biri varsa ona pass at
            // Radarda biri yoksa baktığı yöne pass at
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            Events.OnPassKeyTriggered.RemoveListener(Execute);
        }
    }
}