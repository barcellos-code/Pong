using BallPresenter;

namespace ConsoleBallView;

internal class BallView : IBallView
{
    public void DrawBall(int posX, int posY)
    {
        Console.SetCursorPosition(posX, posY);
        Console.Write("O");
    }
}
