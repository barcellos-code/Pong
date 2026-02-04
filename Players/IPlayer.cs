namespace Players;

public interface IPlayer
{
    int Score {get; }
    event Action<int> OnScoreUpdated;
}
