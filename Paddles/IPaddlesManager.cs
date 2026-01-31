namespace Paddles
{
    public interface IPaddlesManager : IDisposable
    {
        int NumberOfPaddles { get; }
        void CreatePaddles(int numberOfPaddles, int paddleSize, int stageWidth, int stageHeight);
        Paddle Get(int index);
    }
}
