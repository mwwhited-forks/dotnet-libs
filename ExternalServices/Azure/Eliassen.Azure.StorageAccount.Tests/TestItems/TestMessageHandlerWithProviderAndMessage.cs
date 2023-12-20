using Eliassen.Azure.StorageAccount.Tests.MessageQueueing;
using Eliassen.MessageQueueing;
using Eliassen.MessageQueueing.Services;
using Eliassen.TestUtilities;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Eliassen.Azure.StorageAccount.Tests.TestItems;

public class TestMessageHandlerWithProviderAndMessage : IMessageHandler<AzureStorageQueueMessageSenderProviderTests, TestQueueMessage>
{
    private readonly ILogger _logger;
    private readonly TestContext _testContext;

    public TestMessageHandlerWithProviderAndMessage(
        ILogger<TestMessageHandlerWithProviderAndMessage> logger,
        TestContext testContext
        )
    {
        _logger = logger;
        _testContext = testContext;
    }

    public Task HandleAsync(TestQueueMessage message, IMessageContext context)
    {
        _logger.LogInformation("HandleAsync: {message}", message);
        _testContext.AddResult(message, fileName: $"TestMessageHandlerWithProviderAndMessage-Message-{context.Config.Path}");
        return Task.CompletedTask;
    }

    public Task HandleAsync(object message, IMessageContext context)
    {
        if (message is TestQueueMessage received)
            return HandleAsync(received, context);
        return Task.CompletedTask;
    }
}
