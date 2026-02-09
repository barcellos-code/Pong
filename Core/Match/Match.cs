using Container;
using Microsoft.Extensions.DependencyInjection;
using Players;

namespace Match;

internal class Match(int winningScoreValue) : IMatch
{
    public bool IsOngoing { get; private set; }

    private readonly int _winningScoreValue = winningScoreValue;

    public void StartMatch()
    {
        if (IsOngoing)
            throw new InvalidOperationException("This match is already ongoing");
        
        IsOngoing = true;
    }

    public void BindScoreEvents()
    {
        var playersService = DependencyContainer.ServiceProvider?.GetService<IPlayersService>();
        
        for (var i = 0; i < playersService?.NumberOfPlayers; i++)
        {
            var player = playersService?.GetPlayer(i);
            player?.OnScoreUpdated += EndMatchIfPlayerWon;
        }
    }

    private void EndMatchIfPlayerWon(int scoreValue)
    {
        if (scoreValue < _winningScoreValue)
            return;
        
        EndMatch();
    }

    private void EndMatch()
        => IsOngoing = false;
}
