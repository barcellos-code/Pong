namespace BallInteractor;

public interface IBallInteractor
{
    void CreateBall(int stageWidth, int stageHeight, int directionX, int directionY);
    void MoveBall();
}
