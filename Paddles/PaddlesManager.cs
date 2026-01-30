using Players;

namespace Paddles
{
    internal class PaddlesManager : IPaddlesManager
    {
        public int NumberOfPaddles => _paddles.Count;

        private readonly List<Paddle> _paddles = [];

        public void CreatePaddles(int numberOfPaddles, int paddleSize)
        {
            for(var i = 0; i < numberOfPaddles; i++)
            {
                var paddle = new Paddle(paddleSize);
                _paddles.Add(paddle);
            }    
        }

        public Paddle Get(int index)
            => _paddles[index];

        public void Dispose()
        {
            _paddles.Clear();
        }
    }
}
