namespace Game
{
    public interface IGame
    {
        Bounds Bounds { get; }
        int NumberOfPlayers { get; }
        void Create(IGameParameters parameters);
    }
}
