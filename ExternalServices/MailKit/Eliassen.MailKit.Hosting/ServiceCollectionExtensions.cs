using Microsoft.Extensions.DependencyInjection;
using System;

namespace Eliassen.MailKit.Hosting;

/// <summary>
/// Provides extension methods for configuring IoC (Inversion of Control) services
/// to support all Message Queueing within this library.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add IOC configurations to support all Mailkit Hosting within this library.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection TryAddMailKitHosting(this IServiceCollection services)
    {
        //Note: this is the service host to enable the inbound message handlers
        var skip = bool.TryParse(Environment.GetEnvironmentVariable("SWAGGER_ONLY"), out var ret) && ret;
        if (!skip)
        {
            services.AddHostedService<EmailMessageReceiverHost>();
        }
        return services;
    }
}