using BallInteractor;

namespace BallPresenter;

internal class BallPresenter(IBallView ballView) : IBallPresenter
{
    private readonly IBallView _ballView = ballView;

    public void DrawBall(int posX, int posY)
        => _ballView.DrawBall(posX, posY);
}
