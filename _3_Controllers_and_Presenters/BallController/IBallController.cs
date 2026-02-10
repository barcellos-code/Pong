namespace BallController;

public interface IBallController : IDisposable
{
    void CreateBall(int stageWidth, int stageHeight, int directionX, int directionY);
    void BindTickEvent();
}
