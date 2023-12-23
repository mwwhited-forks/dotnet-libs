using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Eliassen.MessageQueueing.Services;

public class MessageReceiverProviderFactory : IMessageReceiverProviderFactory
{
    private readonly IEnumerable<IMessageQueueHandler> _handlers;
    private readonly IMessagePropertyResolver _resolver;
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger _logger;

    public MessageReceiverProviderFactory(
        IEnumerable<IMessageQueueHandler> handlers,
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
                                                        where typeof(IMessageQueueHandler).IsAssignableFrom(@interface)
                                                        orderby @interface.GenericTypeArguments.Length descending
                                                        select @interface
                                let handlerInterface = handlerInterfaces.FirstOrDefault()
                                where handlerInterface != null

                                let channelType = handlerInterface.GenericTypeArguments.FirstOrDefault() ?? typeof(object)
                                let messageType = handlerInterface.GenericTypeArguments.ElementAtOrDefault(1) ?? typeof(object)

                                let provider = _resolver.ProviderSafe(channelType, messageType)
                                let config = _resolver.ConfigurationSafe(channelType, messageType)

                                group new
                                {
                                    handler,
                                    handlerInterface,
                                    provider,
                                    config,
                                } by new
                                {
                                    provider.providerKey,
                                    provider.configPath,
                                    channelType,
                                };

        foreach (var item in handlersByChannel)
        {
            var handlers = item.Select(i => i.handler).ToList();
            if (item.Key.providerKey == null)
            {
                _logger.LogWarning($"No provider configured for handlers {{{nameof(handlers)}}}", handlers);
                continue;
            }

            var receiver = Receiver(item.Key.providerKey);

            var config = item.First().config.configurationSection;

            var disableReceiverValue = config?["DisableReceiver"];
            var disableReceiver =
                string.Equals("TRUE", disableReceiverValue, StringComparison.InvariantCultureIgnoreCase) ||
                string.Equals("1", disableReceiverValue, StringComparison.InvariantCultureIgnoreCase)
                ;

            if (disableReceiver)
            {
                _logger.LogWarning($"Provider disabled for handlers {{{nameof(handlers)}}}", handlers);
                continue;
            }

            var handler = _serviceProvider.GetRequiredService<IMessageHandlerProvider>()
                .SetHandlers(handlers)
                .SetChannelType(item.Key.channelType)
                .SetConfig(config ?? throw new ApplicationException($"Missing Configuration"))
                ;

            receiver.SetHandlerProvider(handler);

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