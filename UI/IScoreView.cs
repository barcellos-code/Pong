namespace UI;

public interface IScoreView : IView
{
    void Update(int playerId, int score, int screenWidth, int screenHeight);
}
