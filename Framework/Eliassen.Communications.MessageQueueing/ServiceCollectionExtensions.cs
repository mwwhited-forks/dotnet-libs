using Eliassen.MessageQueueing;
using Microsoft.Extensions.DependencyInjection;

namespace Eliassen.Communications.MessageQueueing;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection TryAddCommunicationQueueServices(
        this IServiceCollection services
        )
    {
        services.AddTransient<IMessageQueueHandler, EmailMessageHandler>();

        return services;
    }
}
