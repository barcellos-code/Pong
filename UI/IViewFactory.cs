namespace UI;

public interface IViewFactory
{
    IStageView StageView(int width, int height);
    IPaddleView PaddleView(int posX, int posY, int size);
    IBallView BallView(int posX, int posY);
    IScoreView ScoreView(int playerId, int score, int screenWidth, int screenHeight);
}
