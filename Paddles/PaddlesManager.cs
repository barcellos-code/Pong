using Players;

namespace Paddles
{
    internal class PaddlesManager : IPaddlesManager
    {
        public int NumberOfPaddles => _paddles.Count;

        private readonly List<Paddle> _paddles = [];

        public void CreatePaddles(IPlayersParameters playersParameters, IPaddlesParameters paddlesParameters)
        {
            for(var i = 0; i < playersParameters.NumberOfPlayers; i++)
            {
                var paddle = new Paddle(paddlesParameters.PaddleSize);
                _paddles.Add(paddle);
            }    
        }

        public Paddle Get(int index)
            => _paddles[index];
    }
}
