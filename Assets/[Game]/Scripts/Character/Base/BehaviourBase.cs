using _Game_.Scripts.Character.Components;
using _Game_.Scripts.Character.Data;
using _Game_.Scripts.Character.Interfaces;

namespace _Game_.Scripts.Character.Base
{
    public abstract class BehaviourBase : ICharacterBehaviour
    {
        protected readonly CharacterData Data;
        protected readonly CharacterEvents Events;

        protected BehaviourBase(
            CharacterData data,
            CharacterEvents events
        )
        {
            Data = data;
            Events = events;
        }

        public virtual void Activate()
        {
        }

        public virtual void Execute()
        {
            Data.HasBall = false;
            CharacterEvents.OnCourtAreaUpdated?.Invoke(Data.CurrentCourtAreaType);
        }

        public virtual void OnDestroy()
        {
        }
    }
}