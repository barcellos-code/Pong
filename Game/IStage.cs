namespace Stage
{
    public interface IStage : IDisposable
    {
        Bounds Bounds { get; }
        void Create(int width, int height);
    }
}
