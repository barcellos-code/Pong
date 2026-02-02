namespace Ball
{
    public interface IBallService : IDisposable
    {
        void CreateBall(int stageWidth, int stageHeight);
        IBall GetBall();
    }
}
