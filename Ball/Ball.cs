namespace Ball
{
    internal class Ball(int posX, int posY, int dirX, int dirY, int stageHeight) : IBall
    {
        public int PositionX { get; private set; } = posX;

        public int PositionY { get; private set; } = posY;

        public int DirectionX { get; private set; } = dirX;

        public int DirectionY { get; private set; } = dirY;

        private readonly int _stageHeight = stageHeight;

        public void Move()
        {
            BounceOffStageBounds();

            PositionX += DirectionX;
            PositionY += DirectionY;
        }

        private void BounceOffStageBounds()
        {
            if (PositionY >= _stageHeight - 1
                || PositionY <= 0)
                DirectionY *= -1;
        }
    }
}
