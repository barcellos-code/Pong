using PaddlesInteractor;

namespace PaddlePresenter;

internal class PaddlePresenter(IPaddleView paddleView) : IPaddlePresenter
{
    private readonly IPaddleView _paddleView = paddleView;

    public void DrawPaddle(int size, int posX, int posY)
        => _paddleView.DrawPaddle(size, posX, posY);
}
