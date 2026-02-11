namespace BallController;

public interface IBallController
{
    void CreateBall(int stageWidth, int stageHeight, int directionX, int directionY);
    void StartBallTick();
    void StopBallTick();
}
