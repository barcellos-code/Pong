namespace Stage
{
    internal class PongStage : IStage
    {
        public Bounds Bounds { get; private set; }

        public void Create(int width, int height)
        {
            Bounds = new(width, height);
        }

        public void Dispose()
        {
            Bounds = new(0, 0);
        }
    }
}
