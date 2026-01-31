namespace Paddles
{
    internal class PaddlesManager : IPaddlesManager
    {
        public int NumberOfPaddles => _paddles.Count;

        private readonly List<Paddle> _paddles = [];

        public void CreatePaddles(int numberOfPaddles, int paddleSize, int stageWidth, int stageHeight)
        {
            if (numberOfPaddles < 2)
                throw new InvalidOperationException("There must be at least 2 paddles.");

            var firstXPos = 1;
            var lastXPos = stageWidth - 2;
            var deltaX = (lastXPos - firstXPos) / (numberOfPaddles - 1);
            var actualPaddleSize = int.Min(stageHeight, paddleSize);

            _paddles.Add(new(actualPaddleSize, firstXPos));

            for (var i = 1; i < numberOfPaddles - 1; i++)
            {
                var xPos = firstXPos + deltaX * i;
                _paddles.Add(new(actualPaddleSize, xPos));
            }

            _paddles.Add(new(actualPaddleSize, lastXPos));
        }

        public Paddle Get(int index)
            => _paddles[index];

        public void Dispose()
        {
            _paddles.Clear();
        }
    }
}
