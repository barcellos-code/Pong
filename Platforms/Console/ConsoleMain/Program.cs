using Ball;
using Match;
using Microsoft.Extensions.DependencyInjection;
using Paddles;
using Players;
using Stage;
using UI;

namespace ConsoleMain;

internal class Program
{
    // Game Parameters
    private const int NumberOfPlayers = 2;
    private const int StageWidth = 80;
    private const int StageHeight = 25;
    private const int PaddleSize = 5;
    private const int BallInitialDirX = 1;
    private const int BallInitialDirY = 1;
    private const int WinningScore = 5;

    // Services
    private static IStageService? _stageService;
    private static IPaddlesService? _paddlesService;
    private static IBallService? _ballService;
    private static IPlayersService? _playersService;
    private static IMatchService? _matchService;
    private static IViewService? _viewService;
    private static IViewFactory? _viewFactory;

    private static void Main()
    {
        // Inject services
        IServiceProvider serviceProvider = ConsoleContainer.ServiceProvider ?? throw new NullReferenceException($"{nameof(ConsoleContainer)} does not have a {nameof(ServiceProvider)}");
        _stageService = serviceProvider.GetService<IStageService>() ?? throw new NullReferenceException($"Unable to retrieve {nameof(IStageService)}");
        _paddlesService = serviceProvider.GetService<IPaddlesService>() ?? throw new NullReferenceException($"Unable to retrieve {nameof(IPaddlesService)}");
        _ballService = serviceProvider.GetService<IBallService>() ?? throw new NullReferenceException($"Unable to retrieve {nameof(IBallService)}");
        _playersService = serviceProvider.GetService<IPlayersService>() ?? throw new NullReferenceException($"Unable to retrieve {nameof(IPlayersService)}");
        _matchService = serviceProvider.GetService<IMatchService>() ?? throw new NullReferenceException($"Unable to retrieve {nameof(IMatchService)}");
        _viewService = serviceProvider.GetService<IViewService>() ?? throw new NullReferenceException($"Unable to retrieve {nameof(IViewService)}");
        _viewFactory = serviceProvider.GetService<IViewFactory>() ?? throw new NullReferenceException($"Unable to retrieve {nameof(IViewFactory)}");

        // Create game simulation
        _stageService.CreateStage(StageWidth, StageHeight);
        _paddlesService.CreatePaddles(NumberOfPlayers, PaddleSize, StageWidth, StageHeight);
        _ballService.CreateBall(StageWidth, StageHeight, BallInitialDirX, BallInitialDirY);
        _playersService.CreatePlayers(NumberOfPlayers);
        _matchService.CreateMatch(WinningScore);

        // Declare game simulation variables
        var stage = _stageService.GetStage();
        var ball = _ballService.GetBall();

        // Create stage view and add it to view service
        var stageView = _viewFactory.StageView(stage.Width, stage.Height);
        _viewService.AddView(stageView);

        // Create paddle views and add them to view service
        for (var i = 0; i < _paddlesService.NumberOfPaddles; i++)
        {
            var paddle = _paddlesService.GetPaddle(i);
            var paddleView = _viewFactory.PaddleView(paddle.PositionX, paddle.PositionY, paddle.Size);
            _viewService.AddView(paddleView);
        }

        // Create ball view and add it to view service
        var ballView = _viewFactory.BallView(ball.PositionX, ball.PositionY);
        _viewService.AddView(ballView);

        _viewService.DrawAllViews();

        Console.ReadKey();
    }
}
