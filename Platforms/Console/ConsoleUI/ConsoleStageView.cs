using UI;

namespace ConsoleUI;

internal class ConsoleStageView : IStageView
{
    private int _stageWidth, _stageHeight;

    public void Draw()
    {
#pragma warning disable CA1416 // Validate platform compatibility
        Console.SetWindowSize(_stageWidth, _stageHeight);
        Console.SetBufferSize(_stageWidth, _stageHeight);
#pragma warning restore CA1416 // Validate platform compatibility☻
    }

    public void Update(int stageWidth, int stageHeight)
    {
        _stageWidth = stageWidth;
        _stageHeight = stageHeight;
    }
}
