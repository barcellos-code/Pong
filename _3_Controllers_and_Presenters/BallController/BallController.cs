using BallInteractor;

namespace BallController;

internal class BallController(IBallInteractor ballInteractor) : IBallController
{
    private readonly IBallInteractor _ballInteractor = ballInteractor;
    private readonly BallTick _ballTick = new();

    public void CreateBall(int stageWidth, int stageHeight, int directionX, int directionY)
    {
        _ballInteractor.CreateBall(stageWidth, stageHeight, directionX, directionY);
        _ballTick.OnTick += MoveBall;
    }

    public void StartBallTick()
        => _ballTick.StartTick();

    public void StopBallTick()
        => _ballTick.StopTick();

    private void MoveBall()
        => _ballInteractor.MoveBall();
}
