using Container;
using Microsoft.Extensions.DependencyInjection;
using Players;

namespace PlayersInteractor;

internal class PlayersInteractor(IPlayersService playersService) : IPlayersInteractor
{
    private readonly IPlayersService _playersService = playersService;

    public void CreatePlayers(int numberOfPlayers, int screenWidth, int screenHeight)
    {
        _playersService.CreatePlayers(numberOfPlayers);

        for (var i = 0; i < _playersService.NumberOfPlayers; i++)
        {
            var player = _playersService.GetPlayer(i);
            DrawPlayer(player, i, screenWidth, screenHeight);

            player.OnScoreUpdated += _ => DrawPlayer(player, i, screenWidth, screenHeight);
        }
    }

    public void BindGoalEvents()
        => _playersService.BindGoalEvents();
    
    private void DrawPlayer(IPlayer player, int playerIndex, int screenWidth, int screenHeight)
    {
        var serviceProvider = DependencyContainer.ServiceProvider ?? throw new NullReferenceException($"{nameof(DependencyContainer)} does not have a {nameof(ServiceProvider)}");
        var playerPresenter = serviceProvider.GetService<IPlayerPresenter>() ?? throw new NullReferenceException($"Unable to retrieve {nameof(IPlayerPresenter)}");

        playerPresenter.DrawPlayer(playerIndex, player.Score, screenWidth, screenHeight);
    }
}
