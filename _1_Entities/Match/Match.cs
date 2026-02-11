using Container;
using Microsoft.Extensions.DependencyInjection;
using Players;

namespace Match;

internal class Match(int winningScoreValue) : IMatch
{
    public bool IsOngoing { get; private set; }
    public event Action<IPlayer>? OnMatchEnded;

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

    private void EndMatchIfPlayerWon(IPlayer player)
    {
        if (player.Score < _winningScoreValue)
            return;
        
        EndMatch(player);
    }

    private void EndMatch(IPlayer winningPlayer)
    {
        IsOngoing = false;
        OnMatchEnded?.Invoke(winningPlayer);
    }
}
