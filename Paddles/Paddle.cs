namespace Paddles
{
    public class Paddle (int size, int xPos, int yPos, int stageHeight) : IPaddle
    {
        public int Size { get; private set; } = size;
        public int PositionX { get; private set; } = xPos;
        public int PositionY { get; private set; } = yPos;

        private readonly int _stageHeight = stageHeight;

        public void MoveUp()
            => PositionY = int.Min(PositionY + 1, _stageHeight - Size - 1);

        public void MoveDown()
            => PositionY = int.Max(PositionY - 1, 0);
    }
}
