using UI;

namespace ConsoleUI;

internal class ViewFactory : IViewFactory
{
    public IStageView StageView(int width, int height)
        => new StageView(width, height);
    
    public IPaddleView PaddleView(int posX, int posY, int size)
        => new PaddleView(posX, posY, size);
    
    public IBallView BallView(int posX, int posY)
        => new BallView(posX, posY);
    
    public IScoreView ScoreView(int playerId, int score, int screenWidth, int screenHeight)
        => new ScoreView(playerId, score, screenWidth, screenHeight);
}
