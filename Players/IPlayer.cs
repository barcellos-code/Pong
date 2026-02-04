namespace Players;

public interface IPlayer
{
    int Score {get; }

    void BindGoalEvent(int goalIndex);
}
