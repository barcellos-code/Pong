using Match;
using Players;

namespace MatchInteractor;

internal class MatchInteractor(IMatchService matchService, IMatchPresenter matchPresenter) : IMatchInteractor
{
    private readonly IMatchService _matchService = matchService;
    private readonly IMatchPresenter _matchPresenter = matchPresenter;

    private int _screenWidth;
    private int _screenHeight;

    public void CreateMatch(int winningScoreValue, int screenWidth, int screenHeight)
    {
        _screenWidth = screenWidth;
        _screenHeight = screenHeight;

        _matchService.CreateMatch(winningScoreValue);
        BindMatchEndedEvent();
    }

    public void BindScoreEvents()
        => _matchService.BindScoreEvents();

    private void BindMatchEndedEvent()
    {
        var match = _matchService.GetMatch();
        match.OnMatchEnded += OnMatchEnded;
    }

    private void OnMatchEnded(IPlayer winningPlayer)
        => _matchPresenter.DrawMatchEnded(winningPlayer.Index, _screenWidth, _screenHeight);
}
