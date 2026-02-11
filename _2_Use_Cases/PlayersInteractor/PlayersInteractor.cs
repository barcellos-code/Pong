using Container;
using Microsoft.Extensions.DependencyInjection;
using Players;

namespace PlayersInteractor;

internal class PlayersInteractor(IPlayersService playersService) : IPlayersInteractor
{
    private readonly IPlayersService _playersService = playersService;

    private int _screenWidth;
    private int _screenHeight;

    public void CreatePlayers(int numberOfPlayers, int screenWidth, int screenHeight)
    {
        _screenWidth = screenWidth;
        _screenHeight = screenHeight;

        _playersService.CreatePlayers(numberOfPlayers);
        DrawPlayers();

        BindScoreEvents();
    }

    public void BindGoalEvents()
        => _playersService.BindGoalEvents();
    
    private void BindScoreEvents()
    {
        for (var i = 0; i < _playersService.NumberOfPlayers; i++)
        {
            var player = _playersService.GetPlayer(i);
            player.OnScoreUpdated += OnScoreUpdated;
        }
    }
    
    private void OnScoreUpdated(int _)
        => DrawPlayers();
    
    private void DrawPlayers()
    {
        for (var i = 0; i < _playersService.NumberOfPlayers; i++)
        {
            var player = _playersService.GetPlayer(i);
            DrawPlayer(player, i, _screenWidth, _screenHeight);
        }
    }
    
    private void DrawPlayer(IPlayer player, int playerIndex, int screenWidth, int screenHeight)
    {
        var serviceProvider = DependencyContainer.ServiceProvider ?? throw new NullReferenceException($"{nameof(DependencyContainer)} does not have a {nameof(ServiceProvider)}");
        var playerPresenter = serviceProvider.GetService<IPlayerPresenter>() ?? throw new NullReferenceException($"Unable to retrieve {nameof(IPlayerPresenter)}");

        playerPresenter.DrawPlayer(playerIndex, player.Score, screenWidth, screenHeight);
    }
}
