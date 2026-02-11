using PaddlesInteractor;

namespace PaddlesController;

internal class PaddlesController(IPaddlesInteractor paddlesInteractor, IPaddlesInputService inputService) : IPaddlesController
{
    private readonly IPaddlesInteractor _paddlesInteractor = paddlesInteractor;
    private readonly IPaddlesInputService _inputService = inputService;

    public void CreatePaddles(int numberOfPaddles, int paddleSize, int stageWidth, int stageHeight)
    {
        _paddlesInteractor.CreatePaddles(numberOfPaddles, paddleSize, stageWidth, stageHeight);

        BindInputEvents();
        StartInputHandling();
    }

    private void BindInputEvents()
        => _inputService.OnInput += OnInput;
    
    private void StartInputHandling()
        => _inputService.StartInputHandling();

    private void OnInput(int paddleIndex, PaddlesInputDirection inputDirection)
    {
        var paddleDirection = inputDirection == PaddlesInputDirection.Up
            ? PaddleMovementDirection.Up
            : PaddleMovementDirection.Down;
        
        _paddlesInteractor.MovePaddle(paddleIndex, paddleDirection);
    }
}
