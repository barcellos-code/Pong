namespace Players
{
    internal class PlayersManager : IPlayersManager, IDisposable
    {
        public int NumberOfPlayers => _players.Count;

        private readonly List<Player> _players = [];

        public void Create(int numberOfPlayers)
        {
            for (var i = 0; i < numberOfPlayers; i++)
            {
                var player = new Player();
                _players.Add(player);
            }
        }

        public void Dispose()
        {
            _players.Clear();
        }
    }
}
