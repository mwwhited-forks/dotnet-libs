using Eliassen.MessageQueueing;
using Eliassen.MessageQueueing.Services;
using Eliassen.TestUtilities;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Eliassen.Azure.StorageAccount.Tests.TestItems;

public class TestMessageHandler : IMessageQueueHandler
{
    private readonly ILogger _logger;
    private readonly TestContext _testContext;

    public TestMessageHandler(
        ILogger<TestMessageHandler> logger,
        TestContext testContext
        )
    {
        _logger = logger;
        _testContext = testContext;
    }

    public Task HandleAsync(object message, IMessageContext context)
    {
        _logger.LogInformation("HandleAsync: {message}", message);
        _testContext.AddResult(message, fileName: $"TestMessageHandler-Message-{context.Config.Path}");
        return Task.CompletedTask;
    }
}
