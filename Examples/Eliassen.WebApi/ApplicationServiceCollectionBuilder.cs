using Eliassen.MessageQueueing;
using Eliassen.WebApi.Provider;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Eliassen.WebApi;

public static class ApplicationServiceCollectionBuilder
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.TryAddTransient<IExampleMessageProvider, ExampleMessageProvider>();
        services.TryAddTransient<IMessageQueueHandler, ExampleMessageProvider>();
        return services;
    }
}
