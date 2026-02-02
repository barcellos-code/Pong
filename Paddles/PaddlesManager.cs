namespace Paddles
{
    internal class PaddlesManager : IPaddlesManager
    {
        public int NumberOfPaddles => _paddles.Count;

        private readonly List<Paddle> _paddles = [];

        public void CreatePaddles(int numberOfPaddles, int paddleSize, int stageWidth,
            int stageHeight)
        {
            if (numberOfPaddles < 2)
                throw new InvalidOperationException("There must be at least 2 paddles.");

            var firstXPos = 1;
            var lastXPos = stageWidth - 2;
            var deltaX = (lastXPos - firstXPos) / (numberOfPaddles - 1);
            var actualPaddleSize = int.Min(stageHeight, paddleSize);
            var yPos = (stageHeight / 2) - (actualPaddleSize / 2);

            _paddles.Add(new(actualPaddleSize, firstXPos, yPos, stageHeight));

            for (var i = 1; i < numberOfPaddles - 1; i++)
            {
                var xPos = firstXPos + deltaX * i;
                _paddles.Add(new(actualPaddleSize, xPos, yPos, stageHeight));
            }

            _paddles.Add(new(actualPaddleSize, lastXPos, yPos, stageHeight));
        }

        public IPaddle Get(int index)
            => _paddles[index];

        public void Dispose()
        {
            _paddles.Clear();
        }
    }
}
