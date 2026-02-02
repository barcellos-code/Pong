namespace Players
{
    internal class PlayersService : IPlayersService, IDisposable
    {
        public int NumberOfPlayers => _players.Count;

        private readonly List<Player> _players = [];

        public void CreatePlayers(int numberOfPlayers)
        {
            for (var i = 0; i < numberOfPlayers; i++)
            {
                var player = new Player();
                _players.Add(player);
            }
        }

        public void Dispose()
            => _players.Clear();
    }
}
