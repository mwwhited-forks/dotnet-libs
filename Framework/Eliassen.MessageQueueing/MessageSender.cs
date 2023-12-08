using Eliassen.MessageQueueing.Services;
using System.Threading.Tasks;

namespace Eliassen.MessageQueueing;

public class MessageSender<TQueueTarget> : IMessageSender<TQueueTarget>
{
    private readonly IMessageSenderContextFactory _context;
    private readonly IMessageSenderProviderFactory _provider;
    private readonly IMessageSenderResolver _resolver;

    public MessageSender(
        IMessageSenderContextFactory context,
        IMessageSenderProviderFactory provider,
        IMessageSenderResolver resolver
        )
    {
        _context = context;
        _provider = provider;
        _resolver = resolver;
    }

    public async Task<string> SendAsync(object message, string? messageId = default)
    {
        //TODO: add useful logging
        var targetType = typeof(TQueueTarget);
        var messageType = message.GetType();

        messageId = _resolver.MessageId(targetType, messageType, messageId);
        var config = _resolver.Configuration(targetType, messageType);
        var context = _context.Create(targetType, messageType, messageId, config);
        var provider = _provider.Create(targetType, messageType);

        var correlationId = await provider.SendAsync(message, context);
        if (!string.IsNullOrWhiteSpace(correlationId))
            context.MessageId = correlationId;

        return context.MessageId;
    }
}
