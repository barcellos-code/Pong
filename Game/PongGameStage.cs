namespace GameStage
{
    internal class PongGameStage : IGameStage
    {
        public Bounds Bounds { get; private set; }

        public void Create(int width, int height)
        {
            Bounds = new(width, height);
        }
    }
}
