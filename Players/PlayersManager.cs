namespace Players
{
    internal class PlayersManager : IPlayersManager
    {
        public int NumberOfPlayers => _players.Count;

        private readonly List<Player> _players = [];

        public void Create(IPlayersParameters parameters)
        {
            for (var i = 0; i < parameters.NumberOfPlayers; i++)
            {
                var player = new Player();
                _players.Add(player);
            }
        }
    }
}
