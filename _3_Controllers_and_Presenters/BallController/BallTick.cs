namespace BallController;

internal class BallTick
{
    private const int Milliseconds = 500;

    public event Action? OnTick;

    private bool _isActive;
    private Thread? _tickRoutineThread;

    public void StartTick()
    {
        _tickRoutineThread = new Thread(TickRoutine);
        _isActive = true;
        _tickRoutineThread.Start();
    }

    public void StopTick()
        => _isActive = false;

    private void TickRoutine()
    {
        while (_isActive)
        {
            OnTick?.Invoke();
            Thread.Sleep(Milliseconds);
        }
    }
}
