namespace GameStage
{
    public interface IGameStage : IDisposable
    {
        Bounds Bounds { get; }
        void Create(int width, int height);
    }
}
