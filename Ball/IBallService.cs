namespace Ball
{
    public interface IBallService : IDisposable
    {
        void CreateBall(int stageWidth, int stageHeight, int directionX, int directionY);
        IBall GetBall();
    }
}
