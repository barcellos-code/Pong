namespace GameStage
{
    public interface IGameStage
    {
        Bounds Bounds { get; }
        void Create(IGameStageParameters parameters);
    }
}
