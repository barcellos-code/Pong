namespace Match;

public interface IMatch
{
    bool IsOngoing { get; }
    void StartMatch();
}
