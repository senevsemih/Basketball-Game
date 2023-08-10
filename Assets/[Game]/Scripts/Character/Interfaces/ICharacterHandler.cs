namespace _Game_.Scripts.Character.Interfaces
{
    public interface ICharacterHandler
    {
        void Tick();
        void FixedTick();
        void OnDestroy();
    }
}