using Players;

namespace Paddles
{
    internal class PaddlesManager : IPaddlesManager
    {
        public int NumberOfPaddles => _paddles.Count;

        private readonly List<Paddle> _paddles = [];

        public void CreatePaddles(IPlayersParameters playersParameters)
        {
            for(var i = 0; i < playersParameters.NumberOfPlayers; i++)
            {
                var paddle = new Paddle();
                _paddles.Add(paddle);
            }    
        }
    }
}
