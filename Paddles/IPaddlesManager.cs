using Players;

namespace Paddles
{
    public interface IPaddlesManager
    {
        int NumberOfPaddles { get; }
        void CreatePaddles(IPlayersManager players);
    }
}
