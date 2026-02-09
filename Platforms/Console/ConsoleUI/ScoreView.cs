using UI;

namespace ConsoleUI;

public class ScoreView(int playerId, int score, int screenWidth, int screenHeight) : IScoreView
{
    private const float HorizontalOffsetFactor = 0.25f;

    private int _playerId = playerId;
    private int _score = score;
    private int _screenWidth = screenWidth;
    private int _screenHeight = screenHeight;

    public void Draw()
    {
        var left = _playerId == 1
            ? (int)(_screenWidth * HorizontalOffsetFactor)
            : (int)(_screenWidth * (1 - HorizontalOffsetFactor));
        
        var top = _screenHeight - 1;
        
        Console.SetCursorPosition(left, top);
        Console.Write($"Player {_playerId}: {_score}");
    }

    public void Update(int playerId, int score, int screenWidth, int screenHeight)
    {
        _playerId = playerId;
        _score = score;
        _screenWidth = screenWidth;
        _screenHeight = screenHeight;
    }
}
