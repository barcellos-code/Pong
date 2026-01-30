namespace Game
{
    internal class PongGame : IGame
    {
        public Bounds Bounds { get; private set; }
        public int NumberOfPlayers { get; set; }

        public void Create(IGameParameters parameters)
        {
            var width = parameters.Width;
            var height = parameters.Height;
            var numberOfPlayers = parameters.NumberOfPlayers;
            Bounds = new(width, height);
            NumberOfPlayers = numberOfPlayers;
        }
    }
}
