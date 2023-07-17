using UnityEngine;

namespace _Game_.Scripts.Character.Other.Animation
{
    public class PassAnimationKey : MonoBehaviour
    {
        private CharacterEvents _events;

        private void Awake() => _events = GetComponentInParent<CharacterEvents>();
        public void PassKey() => _events.OnPassKeyTriggered?.Invoke();
    }
}