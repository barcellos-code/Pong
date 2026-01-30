namespace Players
{
    public interface IPlayersManager : IDisposable
    {
        int NumberOfPlayers { get; }
        void Create(int numberOfPlayers);
    }
}
