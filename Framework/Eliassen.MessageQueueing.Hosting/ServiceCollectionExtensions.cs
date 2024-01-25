using Microsoft.Extensions.DependencyInjection;
using System;

namespace Eliassen.MessageQueueing.Hosting;

/// <summary>
/// Provides extension methods for configuring IoC (Inversion of Control) services
/// to support all Message Queueing within this library.
/// </summary>
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
        var skip = bool.TryParse(Environment.GetEnvironmentVariable("SWAGGER_ONLY"), out var ret) && ret;
        if (!skip)
        {
            services.AddHostedService<MessageReceiverHost>();
        }
        return services;
    }
}
