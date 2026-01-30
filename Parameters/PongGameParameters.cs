using Game;

namespace Parameters
{
    internal class PongGameParameters : IGameParameters
    {
        public int Width => 80;
        public int Height => 25;

        public int NumberOfPlayers => 2;
    }
}
