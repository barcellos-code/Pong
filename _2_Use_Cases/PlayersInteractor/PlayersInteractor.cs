using Players;

namespace PlayersInteractor;

internal class PlayersInteractor(IPlayersService playersService, IPlayerPresenter playerPresenter) : IPlayersInteractor
{
    private readonly IPlayersService _playersService = playersService;
    private readonly IPlayerPresenter _playerPresenter = playerPresenter;

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
        _playerPresenter.DrawPlayer(playerIndex, player.Score, screenWidth, screenHeight);
    }
}
