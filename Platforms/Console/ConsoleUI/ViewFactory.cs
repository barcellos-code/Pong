using UI;

namespace ConsoleUI;

internal class ViewFactory : IViewFactory
{
    public IStageView StageView(int width, int height)
        => new StageView(width, height);
    
    public IPaddleView PaddleView(int posX, int posY, int size)
        => new PaddleView(posX, posY, size);
}
