using PaddlePresenter;

namespace ConsolePaddleView;

internal class PaddleView : IPaddleView
{
    public void DrawPaddle(int size, int posX, int posY)
    {
        for (int i = 0; i < size; i++)
        {
            Console.SetCursorPosition(posX, posY + i);
            Console.Write("|");
        }
    }
}
