using Eliassen.Azure.StorageAccount.Tests.MessageQueueing;
using Eliassen.MessageQueueing;
using Eliassen.MessageQueueing.Services;
using Eliassen.TestUtilities;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Eliassen.Azure.StorageAccount.Tests.TestItems;

public class TestMessageHandlerWithProviderAndMessage(
    ILogger<TestMessageHandlerWithProviderAndMessage> logger,
    TestContext testContext
        ) : IMessageQueueHandler<AzureStorageQueueMessageSenderProviderTests, TestQueueMessage>
{
    private readonly ILogger _logger = logger;

    public Task HandleAsync(TestQueueMessage message, IMessageContext context)
    {
        _logger.LogInformation("HandleAsync: {message}", message);
        testContext.AddResult(message, fileName: $"TestMessageHandlerWithProviderAndMessage-Message-{context.Config.Path}");
        return Task.CompletedTask;
    }

    public Task HandleAsync(object message, IMessageContext context) => message is TestQueueMessage received ? HandleAsync(received, context) : Task.CompletedTask;
}
