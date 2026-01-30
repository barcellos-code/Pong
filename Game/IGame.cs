namespace Game
{
    public interface IGame
    {
        Bounds Bounds { get; }
        void Create(IGameParameters parameters);
    }
}
