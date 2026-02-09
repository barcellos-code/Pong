using Ball;
using ConsoleUI;
using Container;
using Match;
using Microsoft.Extensions.DependencyInjection;
using Paddles;
using Players;
using Stage;
using UI;

namespace ConsoleMain;

internal static class ConsoleContainer
{
    public static IServiceProvider ServiceProvider
    {
        get
        {
            if (_serviceProvider == null)
            {
                _serviceProvider = BuildServiceProvider();
                DependencyContainer.ServiceProvider = _serviceProvider;
                return _serviceProvider;
            }

            return _serviceProvider;
        }
    }

    private static IServiceProvider? _serviceProvider;

    private static ServiceProvider BuildServiceProvider()
    {
        var serviceCollection = new ServiceCollection();
        
        serviceCollection.AddSingleton<IBallService, BallService>();
        serviceCollection.AddSingleton<IMatchService, MatchService>();
        serviceCollection.AddSingleton<IPaddlesService, PaddlesService>();
        serviceCollection.AddSingleton<IPlayersService, PlayersService>();
        serviceCollection.AddSingleton<IStageService, StageService>();
        serviceCollection.AddSingleton<IViewService, ConsoleViewService>();
        serviceCollection.AddSingleton<IViewFactory, ViewFactory>();

        return serviceCollection.BuildServiceProvider();
    }
}
