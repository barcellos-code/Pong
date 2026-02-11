namespace MatchInteractor;

public interface IMatchInteractor
{
    void CreateMatch(int winningScoreValue, int screenWidth, int screenHeight);
    void BindScoreEvents();
}
