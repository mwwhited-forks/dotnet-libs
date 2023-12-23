using Microsoft.Extensions.DependencyInjection;
using System;

namespace Eliassen.MessageQueueing.Services;

/// <summary>
/// Factory for creating instances of <see cref="IMessageSenderProvider"/> based on channel and message types.
/// </summary>
public class MessageSenderProviderFactory : IMessageSenderProviderFactory
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IMessagePropertyResolver _resolver;

    /// <summary>
    /// Initializes a new instance of the <see cref="MessageSenderProviderFactory"/> class.
    /// </summary>
    /// <param name="serviceProvider">The service provider used for resolving services.</param>
    /// <param name="resolver">The message property resolver.</param>
    public MessageSenderProviderFactory(
        IServiceProvider serviceProvider,
        IMessagePropertyResolver resolver
        )
    {
        _serviceProvider = serviceProvider;
        _resolver = resolver;
    }

    /// <summary>
    /// Creates an instance of <see cref="IMessageSenderProvider"/> based on channel and message types.
    /// </summary>
    /// <param name="channelType">The type of the communication channel.</param>
    /// <param name="messageType">The type of the message.</param>
    /// <returns>An instance of <see cref="IMessageSenderProvider"/>.</returns>
    public virtual IMessageSenderProvider Sender(Type channelType, Type messageType)
    {
        var providerKey = _resolver.Provider(channelType, messageType);

        var provider = _serviceProvider.GetKeyedService<IMessageSenderProvider>(providerKey);

        if (provider == null)
        {
            var providerType = Type.GetType(providerKey, true) ??
                throw new ApplicationException($"Unable to resolve type for {providerKey}");

            provider = (IMessageSenderProvider)ActivatorUtilities.CreateInstance(_serviceProvider, providerType);
        }

        return provider;
    }
}