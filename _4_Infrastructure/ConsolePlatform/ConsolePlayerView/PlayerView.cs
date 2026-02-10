using PlayerPresenter;

namespace ConsolePlayerView;

internal class PlayerView : IPlayerView
{
    private const float HorizontalOffsetFactor = 0.25f;

    public void DrawPlayer(int playerId, int score, int screenWidth, int screenHeight)
    {
        var left = playerId == 1
            ? (int)(screenWidth * HorizontalOffsetFactor)
            : (int)(screenWidth * (1 - HorizontalOffsetFactor));
        
        var top = screenHeight - 1;
        
        Console.SetCursorPosition(left, top);
        Console.Write($"Player {playerId}: {score}");
    }
}
