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
        services.TryAddTransient<IMessageSender, MessageSender<object>>();

        services.TryAddTransient<IMessageContext, MessageContext>();

        services.TryAddTransient<IMessageContextFactory, MessageContextFactory>();
        services.TryAddTransient<IMessageSenderProviderFactory, MessageSenderProviderFactory>();
        services.TryAddTransient<IMessagePropertyResolver, MessagePropertyResolver>();

        return services;
    }
}