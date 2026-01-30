namespace Paddles
{
    public class Paddle (int size, int xPos)
    {
        public int Size { get; private set; } = size;
        public int PositionX { get; private set; } = xPos;
    }
}
