using Players;

namespace Paddles
{
    public interface IPaddlesManager : IDisposable
    {
        int NumberOfPaddles { get; }
        void CreatePaddles(int numberOfPaddles, int paddleSize);
        Paddle Get(int index);
    }
}
