using Microsoft.Extensions.DependencyInjection;

namespace Eliassen.Communications;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection TryAddCommunicationsServices(
        this IServiceCollection services
        )
    {
        return services;
    }
}
