using Microsoft.Extensions.DependencyInjection;

namespace Paddles;

public static class PaddlesContainer
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
        
        serviceCollection.AddSingleton<IPaddlesService, PaddlesService>();

        return serviceCollection.BuildServiceProvider();
    }
}
