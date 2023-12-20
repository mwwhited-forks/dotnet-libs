using Eliassen.Azure.StorageAccount.Tests.MessageQueueing;
using Eliassen.MessageQueueing;
using Eliassen.MessageQueueing.Services;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Eliassen.Azure.StorageAccount.Tests.TestItems;

public class TestMessageHandlerWithProvider : IMessageHandler<AzureStorageQueueMessageSenderProviderTests>
{
    private readonly ILogger _logger;

    public TestMessageHandlerWithProvider(
        ILogger<TestMessageHandlerWithProvider> logger
        )
    {
        _logger = logger;
    }

    public Task HandleAsync(object message, IMessageContext context)
    {
        _logger.LogInformation("HandleAsync: {message}", message);
        return Task.CompletedTask;
    }
}
