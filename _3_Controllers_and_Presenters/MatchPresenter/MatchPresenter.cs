using MatchInteractor;

namespace MatchPresenter;

public class MatchPresenter(IMatchView matchView) : IMatchPresenter
{
    private readonly IMatchView _matchView = matchView;

    public void DrawMatchEnded(int winningPlayerIndex, int screenWidth, int screenHeight)
    {
        var winningPlayerId = winningPlayerIndex + 1;
        _matchView.DrawMatchEnded(winningPlayerId, screenWidth, screenHeight);
    }
}
