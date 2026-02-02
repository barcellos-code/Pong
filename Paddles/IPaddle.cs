namespace Paddles
{
    public interface IPaddle
    {
        int Size { get; }
        int PositionX { get; }
        int PositionY { get; }
        void MoveUp();
        void MoveDown();
    }
}
