using Game;
using Microsoft.Extensions.DependencyInjection;
using Paddles;
using Parameters;

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
            collection.AddSingleton<IGame, PongGame>();
            collection.AddSingleton<IGameParameters, PongGameParameters>();
            collection.AddSingleton<IPaddlesManager, PaddlesManager>();

            return collection.BuildServiceProvider();
        }
    }
}
