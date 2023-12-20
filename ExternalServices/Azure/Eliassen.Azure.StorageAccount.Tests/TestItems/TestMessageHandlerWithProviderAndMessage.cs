using Eliassen.Azure.StorageAccount.Tests.MessageQueueing;
using Eliassen.MessageQueueing;
using Eliassen.MessageQueueing.Services;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Eliassen.Azure.StorageAccount.Tests.TestItems;

public class TestMessageHandlerWithProviderAndMessage : IMessageHandler<AzureStorageQueueMessageSenderProviderTests, TestQueueMessage>
{
    private readonly ILogger _logger;

    public TestMessageHandlerWithProviderAndMessage(
        ILogger<TestMessageHandlerWithProviderAndMessage> logger
        )
    {
        _logger = logger;
    }

    public Task HandleAsync(TestQueueMessage message, IMessageContext context)
    {
        _logger.LogInformation("HandleAsync: {message}", message);
        return Task.CompletedTask;
    }

    public Task HandleAsync(object message, IMessageContext context)
    {
        if (message is TestQueueMessage received)
            return HandleAsync(received, context);
        return Task.CompletedTask;
    }
}
