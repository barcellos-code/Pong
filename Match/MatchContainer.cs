using Microsoft.Extensions.DependencyInjection;

namespace Match;

public class MatchContainer
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
        
        serviceCollection.AddSingleton<IMatchService, MatchService>();

        return serviceCollection.BuildServiceProvider();
    }
}
