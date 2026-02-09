namespace UI;

public interface IViewFactory
{
    IStageView StageView(int width, int height);
    IPaddleView PaddleView(int posX, int posY, int size);
}
