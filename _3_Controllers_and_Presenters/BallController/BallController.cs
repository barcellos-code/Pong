using BallInteractor;
using MatchInteractor;

namespace BallController;

internal class BallController(IBallInteractor ballInteractor, IMatchInteractor matchInteractor) : IBallController
{
    private readonly IBallInteractor _ballInteractor = ballInteractor;
    private readonly IMatchInteractor  _matchInteractor = matchInteractor;
    private readonly BallTick _ballTick = new();

    public void CreateBall(int stageWidth, int stageHeight, int directionX, int directionY)
    {
        _ballInteractor.CreateBall(stageWidth, stageHeight, directionX, directionY);
        _ballTick.OnTick += MoveBall;
    }

    public void StartBallTick()
    {
        _ballTick.StartTick();
        BindMatchEndedEvent();
    }

    private void BindMatchEndedEvent()
        => _matchInteractor.OnMatchEnded += StopBallTick;

    private void StopBallTick()
    {
        _ballTick.StopTick();
        UnbindMatchEndedEvent();
    }

    private void UnbindMatchEndedEvent()
        => _matchInteractor.OnMatchEnded -= StopBallTick;

    private void MoveBall()
        => _ballInteractor.MoveBall();
}
