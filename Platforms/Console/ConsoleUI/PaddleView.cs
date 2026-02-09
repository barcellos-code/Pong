using UI;

namespace ConsoleUI;

public class PaddleView(int posX, int posY, int size) : IPaddleView
{
    private int _positionX = posX;
    private int _positionY = posY;
    private int _size = size;

    public void Draw()
    {
        for (int i = 0; i < _size; i++)
        {
            Console.SetCursorPosition(_positionX, _positionY + i);
            Console.Write("|");
        }
    }

    public void Update(int posX, int posY, int size)
    {
        _positionX = posX;
        _positionY = posY;
        _size = size;
    }
}
