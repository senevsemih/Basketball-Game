using _Game_.Scripts.Character.Base;

namespace _Game_.Scripts.Character.Other.Animation
{
    public class ShootAnimationKey : AnimationKeyBase
    {
        public void ShootKey() => Events.onShootKeyTriggered?.Invoke();
    }
}