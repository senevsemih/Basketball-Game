using _Game_.Scripts.Character.Base;

namespace _Game_.Scripts.Character.Other.Animation
{
    public class PassAnimationKey : AnimationKeyBase
    {
        public void PassKey() => Events.onPassKeyTriggered?.Invoke();
    }
}