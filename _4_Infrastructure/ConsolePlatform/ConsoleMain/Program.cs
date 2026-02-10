using BallController;
using Microsoft.Extensions.DependencyInjection;
using PaddlesController;
using PlayersController;
using StageController;
using Tick;

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

    private static void Main()
    {
        // Retrieve Service Provider
        IServiceProvider serviceProvider = ConsoleContainer.ServiceProvider ?? throw new NullReferenceException($"{nameof(ConsoleContainer)} does not have a {nameof(ServiceProvider)}");
        
        // Retrieve Controllers
        var ballController = serviceProvider.GetService<IBallController>() ?? throw new NullReferenceException($"Unable to inject {nameof(IBallController)}");
        var paddlesController = serviceProvider.GetService<IPaddlesController>() ?? throw new NullReferenceException($"Unable to inject {nameof(IPaddlesController)}");
        var playersController = serviceProvider.GetService<IPlayersController>() ?? throw new NullReferenceException($"Unable to inject {nameof(IPlayersController)}");
        var stageController = serviceProvider.GetService<IStageController>() ?? throw new NullReferenceException($"Unable to inject {nameof(IStageController)}");
        var tickService = serviceProvider.GetService<ITickService>() ?? throw new NullReferenceException($"Unable to inject {nameof(ITickService)}");

        // Create Game Entities
        ballController.CreateBall(StageWidth, StageHeight, BallInitialDirX, BallInitialDirY);
        paddlesController.CreatePaddles(NumberOfPlayers, PaddleSize, StageWidth, StageHeight);
        playersController.CreatePlayers(NumberOfPlayers, StageWidth, StageHeight);
        stageController.CreateStage(StageWidth, StageHeight);

        // Bind Events
        playersController.BindGoalEvents();
        ballController.BindTickEvent();

        // Start Game Simulation
        tickService.StartTick();
    }
}
