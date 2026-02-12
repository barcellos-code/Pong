using MatchInteractor;
using PaddlesInteractor;

namespace PaddlesController;

internal class PaddlesController(IPaddlesInteractor paddlesInteractor, IPaddlesInputService inputService, IMatchInteractor matchInteractor) : IPaddlesController
{
    private readonly IPaddlesInteractor _paddlesInteractor = paddlesInteractor;
    private readonly IPaddlesInputService _inputService = inputService;
    private readonly IMatchInteractor _matchInteractor = matchInteractor;

    public void CreatePaddles(int numberOfPaddles, int paddleSize, int stageWidth, int stageHeight)
    {
        _paddlesInteractor.CreatePaddles(numberOfPaddles, paddleSize, stageWidth, stageHeight);

        BindInputEvents();
        StartInputHandling();
        BindMatchEndedEvent();
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

    private void BindMatchEndedEvent()
        => _matchInteractor.OnMatchEnded += OnMatchEnded;

    private void OnMatchEnded()
    {
        UnbindMatchEndedEvent();
        StopInputHandling();
    }

    private void UnbindMatchEndedEvent()
        => _matchInteractor.OnMatchEnded -= OnMatchEnded;

    private void StopInputHandling()
        => _inputService.StopInputHandling();
}
