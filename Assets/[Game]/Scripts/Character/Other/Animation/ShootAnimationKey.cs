using UnityEngine;

namespace _Game_.Scripts.Character.Other.Animation
{
    public class ShootAnimationKey : MonoBehaviour
    {
        private CharacterEvents _events;

        private void Awake() => _events = GetComponentInParent<CharacterEvents>();
        public void ShootKey() => _events.OnShootKeyTriggered?.Invoke();
    }
}