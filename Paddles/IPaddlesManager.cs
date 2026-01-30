using Players;

namespace Paddles
{
    public interface IPaddlesManager
    {
        int NumberOfPaddles { get; }
        void CreatePaddles(IPlayersParameters playersParameters, IPaddlesParameters paddlesParameters);
        Paddle Get(int index);
    }
}
