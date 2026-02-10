using PlayersInteractor;

namespace PlayersController;

internal class PlayersController(IPlayersInteractor playersInteractor) : IPlayersController
{
    private readonly IPlayersInteractor _playersInteractor = playersInteractor;

    public void CreatePlayers(int numberOfPlayers, int screenWidth, int screenHeight)
        => _playersInteractor.CreatePlayers(numberOfPlayers, screenWidth, screenHeight);
    
    public void BindGoalEvents()
        => _playersInteractor.BindGoalEvents();
}
