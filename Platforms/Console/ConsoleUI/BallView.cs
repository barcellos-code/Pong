using UI;

namespace ConsoleUI;

internal class BallView(int posX, int posY) : IBallView
{
    private int _positionX = posX;
    private int _positionY = posY;

    public void Draw()
    {
        Console.SetCursorPosition(_positionX, _positionY);
        Console.Write("O");
    }

    public void Update(int posX, int posY)
    {
        _positionX = posX;
        _positionY = posY;
    }
}
