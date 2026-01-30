namespace Players
{
    public interface IPlayersManager
    {
        int NumberOfPlayers { get; }
        void Create(IPlayersParameters parameters);
    }
}
