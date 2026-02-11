using Players;

namespace Match;

public interface IMatch
{
    bool IsOngoing { get; }
    event Action<IPlayer> OnMatchEnded;
    void StartMatch();
}
