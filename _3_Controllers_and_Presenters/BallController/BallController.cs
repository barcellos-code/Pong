using BallInteractor;
using Tick;

namespace BallController;

internal class BallController : IBallController
{
    private readonly IBallInteractor _ballInteractor;
    private readonly ITickService _tickService;

    public BallController(IBallInteractor ballInteractor, ITickService tickService)
    {
        _ballInteractor = ballInteractor;
        _tickService = tickService;
    }

    public void CreateBall(int stageWidth, int stageHeight, int directionX, int directionY)
        => _ballInteractor.CreateBall(stageWidth, stageHeight, directionX, directionY);
    
    public void BindTickEvent()
        => _tickService.OnTick += MoveBall;

    private void MoveBall()
        => _ballInteractor.MoveBall();
    
    public void Dispose()
        => _tickService.OnTick -= MoveBall;
}
