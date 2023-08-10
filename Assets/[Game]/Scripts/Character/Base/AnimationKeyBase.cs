using _Game_.Scripts.Character.Components;
using UnityEngine;

namespace _Game_.Scripts.Character.Base
{
    public abstract class AnimationKeyBase : MonoBehaviour
    {
        protected CharacterEvents Events;
        public virtual void Awake() => Events = GetComponentInParent<CharacterEvents>();
    }
}