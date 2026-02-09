using UI;

namespace ConsoleUI;

internal class StageView(int width, int height) : IStageView
{
    private int _width = width;
    private int _height = height;

    public void Draw()
    {
#pragma warning disable CA1416 // Validate platform compatibility
        Console.SetWindowSize(_width, _height);
        Console.SetBufferSize(_width, _height);
#pragma warning restore CA1416 // Validate platform compatibility☻
    }

    public void Update(int width, int height)
    {
        _width = width;
        _height = height;
    }
}
