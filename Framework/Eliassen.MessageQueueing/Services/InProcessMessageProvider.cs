using Eliassen.MessageQueueing.Services;
using Eliassen.System.Text;
using Eliassen.System.Text.Json.Serialization;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace Eliassen.Azure.StorageAccount.MessageQueueing;

public class InProcessMessageProvider : IMessageSenderProvider, IMessageReceiverProvider
{

    private readonly ISerializer _serializer;
    private readonly ILogger _logger;

    private IMessageHandlerProvider? _handlerProvider;
    private static readonly ConcurrentQueue<WrappedQueueMessage> _queue = new();

    public const string MessageProviderKey = "in-process";

    public InProcessMessageProvider(
        IJsonSerializer serializer,
        ILogger<InProcessMessageProvider> logger
        )
    {
        _serializer = serializer;
        _logger = logger;
    }

    public async Task<string?> SendAsync(object message, IMessageContext context)
    {
        var wrapped = new WrappedQueueMessage
        {
            ContentType = "application/json;",
            PayloadType = message.GetType().AssemblyQualifiedName,
            CorrelationId = context.CorrelationId,
            Payload = message,
            Properties = context.Headers,
        };
        _queue.Enqueue(wrapped);

        return wrapped.CorrelationId;
    }

    public IMessageReceiverProvider SetHandlerProvider(IMessageHandlerProvider handlerProvider)
    {
        _handlerProvider = handlerProvider;
        return this;
    }

    public async Task RunAsync(
        CancellationToken cancellationToken = default
        )
    {
        var newCancellationToken = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken).Token;

        while (!newCancellationToken.IsCancellationRequested)
        {   
            if (!_queue.TryDequeue(out var wrapped))
            {
                _logger.LogInformation($"Nothing Received waiting");
                await Task.Delay(1000);  //TODO: this should be configurable
                continue;
            }

            await _handlerProvider.HandleAsync(wrapped, wrapped.CorrelationId);

            _logger.LogInformation($"Dequeue: {{{nameof(wrapped.CorrelationId)}}}", wrapped.CorrelationId);
        }
    }
}
