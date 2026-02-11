using MatchInteractor;

namespace MatchController;

internal class MatchController(IMatchInteractor matchInteractor) : IMatchController
{
    private readonly IMatchInteractor _matchInteractor = matchInteractor;

    public void CreateMatch(int winningScoreValue, int screenWidth, int screenHeight)
        => _matchInteractor.CreateMatch(winningScoreValue, screenWidth, screenHeight);
    
    public void BindScoreEvents()
        => _matchInteractor.BindScoreEvents();
}
