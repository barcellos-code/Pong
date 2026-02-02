namespace Stage
{
    internal class Stage(int width, int height) : IStage
    {
        public int Width { get; private set; } = width;

        public int Height { get; private set; } = height;
    }
}
