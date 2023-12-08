using Eliassen.MessageQueueing.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Eliassen.MessageQueueing;

/// <inheritdoc/>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add IOC configurations to support all Message Queueing within this library.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection TryAddMessageQueueingExtensions(this IServiceCollection services)
    {
        services.TryAddTransient(typeof(IMessageSender<>), typeof(MessageSender<>));

        services.TryAddTransient<IMessageSenderContext, MessageSenderContext>();
        services.TryAddTransient<IMessageSenderContextFactory, MessageSenderContextFactory>();
        services.TryAddTransient<IMessageSenderProviderFactory, MessageSenderProviderFactory>();
        services.TryAddTransient<IMessageSenderResolver, MessageSenderResolver>();

        return services;
    }
}