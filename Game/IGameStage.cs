namespace GameStage
{
    public interface IGameStage
    {
        Bounds Bounds { get; }
        void Create(int width, int height);
    }
}
