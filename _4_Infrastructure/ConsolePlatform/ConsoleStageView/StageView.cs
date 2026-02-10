using StagePresenter;

namespace ConsoleStageView;

internal class StageView : IStageView
{
    public void DrawStage(int width, int height)
    {
        Console.Title = "Console Pong";
        Console.CursorVisible = false;
        
#pragma warning disable CA1416 // Validate platform compatibility
        Console.SetWindowSize(width, height);
        Console.SetBufferSize(width, height);
#pragma warning restore CA1416 // Validate platform compatibility
    }
}
