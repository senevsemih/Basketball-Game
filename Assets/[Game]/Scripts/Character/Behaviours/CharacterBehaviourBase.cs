using _Game_.Scripts.Character.Data;
using _Game_.Scripts.Character.Interfaces;

namespace _Game_.Scripts.Character.Behaviours
{
    public abstract class CharacterBehaviourBase : IBehaviour
    {
        protected CharacterData Data;
        protected readonly CharacterEvents Events;

        protected CharacterBehaviourBase(
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
        }

        public virtual void OnDestroy()
        {
        }
    }
}