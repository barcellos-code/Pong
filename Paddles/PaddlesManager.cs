using Game;

namespace Paddles
{
    internal class PaddlesManager : IPaddlesManager
    {
        public int NumberOfPaddles => _paddles.Count;

        private readonly List<Paddle> _paddles = [];

        public void CreatePaddles(IGame game)
        {
            for(var i = 0; i < game.NumberOfPlayers; i++)
            {
                var paddle = new Paddle();
                _paddles.Add(paddle);
            }    
        }
    }
}
