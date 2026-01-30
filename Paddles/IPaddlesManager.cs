using Game;

namespace Paddles
{
    public interface IPaddlesManager
    {
        int NumberOfPaddles { get; }
        void CreatePaddles(IGame game);
    }
}
