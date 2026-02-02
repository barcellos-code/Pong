namespace Ball
{
    internal class Ball(int posX, int posY) : IBall
    {
        public int PositionX { get; private set; } = posX;

        public int PositionY { get; private set; } = posY;
    }
}
