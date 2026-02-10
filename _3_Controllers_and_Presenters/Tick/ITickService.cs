namespace Tick;

public interface ITickService
{
    event Action OnTick;
    void StartTick();
    void StopTick();
}
