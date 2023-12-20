using Eliassen.MessageQueueing;
using Eliassen.MessageQueueing.Services;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Eliassen.Azure.StorageAccount.Tests.TestItems;

public class TestMessageHandler : IMessageHandler
{
    private readonly ILogger _logger;

    public TestMessageHandler(
        ILogger<TestMessageHandler> logger
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
