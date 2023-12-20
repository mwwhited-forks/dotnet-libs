using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Eliassen.MessageQueueing.Services;

public class MessageReceiverProviderFactory : IMessageReceiverProviderFactory
{
    private readonly IEnumerable<IMessageHandler> _handlers;
    private readonly IMessagePropertyResolver _resolver;
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger _logger;

    public MessageReceiverProviderFactory(
        IEnumerable<IMessageHandler> handlers,
        IMessagePropertyResolver resolver,
        IServiceProvider serviceProvider,
        ILogger<MessageReceiverProviderFactory> logger
        )
    {
        _handlers = handlers;
        _resolver = resolver;
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    public IEnumerable<IMessageReceiverProvider> Create()
    {
        var handlersByChannel = from handler in _handlers

                                let handlerType = handler.GetType()
                                let handlerInterfaces = from @interface in handlerType.GetInterfaces()
                                                        where typeof(IMessageHandler).IsAssignableFrom(@interface)
                                                        orderby @interface.GenericTypeArguments.Length descending
                                                        select @interface
                                let handlerInterface = handlerInterfaces.FirstOrDefault()
                                where handlerInterface != null

                                let channelType = handlerInterface.GenericTypeArguments.FirstOrDefault() ?? typeof(object)
                                let messageType = handlerInterface.GenericTypeArguments.ElementAtOrDefault(1) ?? typeof(object)

                                let provider = _resolver.ProviderSafe(channelType, messageType)

                                group new
                                {
                                    handler,
                                    handlerInterface,
                                    provider,
                                } by new
                                {
                                    provider,
                                    channelType,
                                    messageType,
                                };

        foreach (var item in handlersByChannel)
        {
            var handlers = item.Select(i => i.handler).ToList();
            if (item.Key.provider.providerKey == null)
            {
                _logger.LogWarning($"No provider configured for handlers {{{nameof(handlers)}}}", handlers);
                continue;
            }

            var receiver = Receiver(item.Key.provider.providerKey);

            var config = _resolver.Configuration(item.Key.channelType, item.Key.messageType);

            receiver.Handlers(handlers);
            receiver.ChannelType(item.Key.channelType);
            receiver.Config(config);

            yield return receiver;
        }
    }

    private IMessageReceiverProvider Receiver(string providerKey)
    {
        var provider = _serviceProvider.GetKeyedService<IMessageReceiverProvider>(providerKey);

        if (provider == null)
        {
            var providerType = Type.GetType(providerKey, true) ??
                throw new ApplicationException($"Unable to resolve type for {providerKey}");

            provider = (IMessageReceiverProvider)ActivatorUtilities.CreateInstance(_serviceProvider, providerType);
        }

        return provider;
    }
}