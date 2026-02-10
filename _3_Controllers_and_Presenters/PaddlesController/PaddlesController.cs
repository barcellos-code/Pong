using PaddlesInteractor;

namespace PaddlesController;

internal class PaddlesController(IPaddlesInteractor paddlesInteractor) : IPaddlesController
{
    private readonly IPaddlesInteractor _paddlesInteractor = paddlesInteractor;

    public void CreatePaddles(int numberOfPaddles, int paddleSize, int stageWidth, int stageHeight)
        => _paddlesInteractor.CreatePaddles(numberOfPaddles, paddleSize, stageWidth, stageHeight);
}
