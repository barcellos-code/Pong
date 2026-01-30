namespace Game
{
    internal class PongGame : IGame
    {
        public Bounds Bounds { get; private set; }

        public void Create(IGameParameters parameters)
        {
            var width = parameters.Width;
            var height = parameters.Height;
            Bounds = new(width, height);
        }
    }
}
