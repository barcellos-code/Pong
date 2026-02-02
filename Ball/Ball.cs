namespace Ball
{
    internal class Ball(int posX, int posY) : IBall
    {
        public int PositionX { get; private set; } = posX;

        public int PositionY { get; private set; } = posY;

        public int DirectionX { get; private set; } = 1;

        public int DirectionY { get; private set; } = 1;
    }
}
