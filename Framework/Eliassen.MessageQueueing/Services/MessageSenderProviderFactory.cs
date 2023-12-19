using Microsoft.Extensions.DependencyInjection;
using System;

namespace Eliassen.MessageQueueing.Services;

public class MessageSenderProviderFactory : IMessageSenderProviderFactory
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IMessageSenderResolver _resolver;

    public MessageSenderProviderFactory(
        IServiceProvider serviceProvider,
        IMessageSenderResolver resolver
        )
    {
        _serviceProvider = serviceProvider;
        _resolver = resolver;
    }

    public virtual IMessageSenderProvider Create(Type targetQueueType, Type messageType)
    {
        var providerKey = _resolver.Provider(targetQueueType, messageType);

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
