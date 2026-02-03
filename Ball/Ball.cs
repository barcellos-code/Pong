namespace Ball
{
    internal class Ball(int posX, int posY, int dirX, int dirY) : IBall
    {
        public int PositionX { get; private set; } = posX;

        public int PositionY { get; private set; } = posY;

        public int DirectionX { get; private set; } = dirX;

        public int DirectionY { get; private set; } = dirY;

        public void Move()
        {
            PositionX += DirectionX;
            PositionY += DirectionY;
        }
    }
}
