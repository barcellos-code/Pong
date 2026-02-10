using Ball;

namespace BallInteractor;

internal class BallInteractor(IBallService ballService, IBallPresenter ballPresenter) : IBallInteractor
{
    private readonly IBallService _ballService = ballService;
    private readonly IBallPresenter _ballPresenter = ballPresenter;

    public void CreateBall(int stageWidth, int stageHeight, int directionX, int directionY)
        => _ballService.CreateBall(stageWidth, stageHeight, directionX, directionY);

    public void MoveBall()
    {
        var ball = _ballService.GetBall();
        ball.Move();
        _ballPresenter.DrawBall(ball.PositionX, ball.PositionY);
    }
}
