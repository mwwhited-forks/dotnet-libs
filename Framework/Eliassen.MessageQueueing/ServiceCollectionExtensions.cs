using Eliassen.Azure.StorageAccount.MessageQueueing;
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
    public static IServiceCollection TryAddMessageQueueingServices(this IServiceCollection services)
    {
        services.TryAddTransient(typeof(IMessageQueueSender<>), typeof(MessageSender<>));
        services.TryAddTransient<IMessageQueueSender, MessageSender<object>>();

        services.TryAddTransient<IMessageContext, MessageContext>();

        services.TryAddTransient<IMessageContextFactory, MessageContextFactory>();
        services.TryAddTransient<IMessageSenderProviderFactory, MessageSenderProviderFactory>();
        services.TryAddTransient<IMessagePropertyResolver, MessagePropertyResolver>();
        services.TryAddTransient<IMessageHandlerProvider, MessageHandlerProvider>();
        services.TryAddTransient<IMessageReceiverProviderFactory, MessageReceiverProviderFactory>();

        services.AddTransient<IMessageSenderProvider, InProcessMessageProvider>();
        services.TryAddKeyedTransient<IMessageSenderProvider, InProcessMessageProvider>(InProcessMessageProvider.MessageProviderKey);

        services.AddTransient<IMessageReceiverProvider, InProcessMessageProvider>();
        services.TryAddKeyedTransient<IMessageReceiverProvider, InProcessMessageProvider>(InProcessMessageProvider.MessageProviderKey);

        return services;
    }
}