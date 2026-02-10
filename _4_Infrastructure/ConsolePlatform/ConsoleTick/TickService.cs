using Tick;

namespace ConsoleTick;

internal class TickService : ITickService
{
    private const int DefaultTickInterval = 500;

    public event Action? OnTick;

    private int _tickInterval = DefaultTickInterval;
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
            Thread.Sleep(_tickInterval);
        }
    }
}
