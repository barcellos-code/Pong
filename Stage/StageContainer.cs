using Microsoft.Extensions.DependencyInjection;

namespace Stage;

public static class StageContainer
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
        
        serviceCollection.AddSingleton<IStageService, StageService>();

        return serviceCollection.BuildServiceProvider();
    }
}
