using Eliassen.WebApi.Workers;
using Microsoft.Extensions.DependencyInjection;

namespace Eliassen.MessageQueueing.Hosting;

/// <inheritdoc/>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add IOC configurations to support all Message Queueing within this library.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection TryAddMessageQueueingHosting(this IServiceCollection services)
    {
        //Note: this is the service host to enable the inbound message handlers
        services.AddHostedService<MessageReceiverHost>();
        return services;
    }
}