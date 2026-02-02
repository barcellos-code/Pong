using Ball;
using Microsoft.Extensions.DependencyInjection;
using Paddles;
using Players;
using Stage;

namespace Pong
{
    public static class GameContainer
    {
        public static IServiceProvider Provider
        {
            get
            {
                if (_provider != null)
                    return _provider;
                
                _provider = BuildProvider();
                return _provider;
            }
        }

        private static IServiceProvider? _provider;

        private static ServiceProvider BuildProvider()
        {
            var collection = new ServiceCollection();

            // Services
            collection.AddSingleton<IStageService, StageService>();
            collection.AddSingleton<IStageParameters, StageParameters>();
            collection.AddSingleton<IPlayersService, PlayersService>();
            collection.AddSingleton<IPlayersParameters, PlayersParameters>();
            collection.AddSingleton<IPaddlesService, PaddlesService>();
            collection.AddSingleton<IPaddlesParameters, PaddlesParameters>();
            collection.AddSingleton<IBallService, BallService>();

            return collection.BuildServiceProvider();
        }
    }
}
