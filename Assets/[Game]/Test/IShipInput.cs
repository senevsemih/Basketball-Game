namespace _Game_.Test
{
    public interface IShipInput
    {
        void ReadInput();
        float Rotation { get; }
        float Thrust { get; }
    }
}