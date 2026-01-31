namespace Paddles
{
    public class Paddle (int size, int xPos, int yPos)
    {
        public int Size { get; private set; } = size;
        public int PositionX { get; private set; } = xPos;
        public int PositionY { get; private set; } = yPos;
    }
}
