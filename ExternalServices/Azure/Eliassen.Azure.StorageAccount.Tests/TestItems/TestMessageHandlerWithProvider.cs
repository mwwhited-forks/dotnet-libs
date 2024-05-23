//using Eliassen.Azure.StorageAccount.Tests.MessageQueueing;
//using Eliassen.MessageQueueing;
//using Eliassen.MessageQueueing.Services;
//using Eliassen.TestUtilities;
//using Microsoft.Extensions.Logging;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System.Threading.Tasks;

//namespace Eliassen.Azure.StorageAccount.Tests.TestItems;

//public class TestMessageHandlerWithProvider(
//    ILogger<TestMessageHandlerWithProvider> logger,
//    TestContext testContext
//        ) : IMessageQueueHandler<AzureStorageQueueMessageSenderProviderTests>
//{
//    private readonly ILogger _logger = logger;

//    public Task HandleAsync(object message, IMessageContext context)
//    {
//        _logger.LogInformation("HandleAsync: {message}", message);
//        testContext.AddResult(message, fileName: $"TestMessageHandlerWithProvider-Message-{context.Config.Path}");
//        return Task.CompletedTask;
//    }
//}
