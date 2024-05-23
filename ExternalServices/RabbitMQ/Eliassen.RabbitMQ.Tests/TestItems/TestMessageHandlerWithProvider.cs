//using Eliassen.MessageQueueing;
//using Eliassen.MessageQueueing.Services;
//using Eliassen.RabbitMQ.Tests.MessageQueueing;
//using Eliassen.TestUtilities;
//using Microsoft.Extensions.Logging;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System.Threading.Tasks;

//namespace Eliassen.RabbitMQ.Tests.TestItems;

//public class TestMessageHandlerWithProvider(
//    ILogger<TestMessageHandlerWithProvider> logger,
//    TestContext testContext
//        ) : IMessageQueueHandler<RabbitMQQueueMessageSenderProviderTests>
//{
//    private readonly ILogger _logger = logger;

//    public Task HandleAsync(object message, IMessageContext context)
//    {
//        _logger.LogInformation("HandleAsync: {message}", message);
//        testContext.AddResult(message, fileName: $"TestMessageHandlerWithProvider-Message-{context.Config.Path}");
//        return Task.CompletedTask;
//    }
//}
