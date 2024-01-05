using Eliassen.MessageQueueing;
using Eliassen.MessageQueueing.Services;
using Eliassen.RabbitMQ.Tests.MessageQueueing;
using Eliassen.TestUtilities;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Eliassen.RabbitMQ.Tests.TestItems;

public class TestMessageHandlerWithProviderAndMessage(
    ILogger<TestMessageHandlerWithProviderAndMessage> logger,
    TestContext testContext
        ) : IMessageQueueHandler<RabbitMQQueueMessageSenderProviderTests, TestQueueMessage>
{
    private readonly ILogger _logger = logger;

    public Task HandleAsync(TestQueueMessage message, IMessageContext context)
    {
        _logger.LogInformation("HandleAsync: {message}", message);
        testContext.AddResult(message, fileName: $"TestMessageHandlerWithProviderAndMessage-Message-{context.Config.Path}");
        return Task.CompletedTask;
    }

    public Task HandleAsync(object message, IMessageContext context)
    {
        if (message is TestQueueMessage received)
            return HandleAsync(received, context);
        return Task.CompletedTask;
    }
}
