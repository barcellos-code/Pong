using Microsoft.Extensions.DependencyInjection;

namespace Ball;

public static class BallContainer
{
    public static IServiceProvider ServiceProvider
    {
        get
        {
            if (_serviceProvider != null)
                return _serviceProvider;
            
            _serviceProvider = BuildServiceProvider();
            return _serviceProvider;
        }
    }

    private static IServiceProvider? _serviceProvider;

    private static ServiceProvider BuildServiceProvider()
    {
        var serviceCollection = new ServiceCollection();
        
        serviceCollection.AddSingleton<IBallService, BallService>();

        return serviceCollection.BuildServiceProvider();
    }
}
