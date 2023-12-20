
using Eliassen.MessageQueueing;

namespace Eliassen.WebApi.Workers;

public class QueueWorker : IHostedService, IDisposable
{
    private readonly ILogger _logger;
    private readonly IEnumerable<IMessageHandler> _handlers;

    public QueueWorker(
        ILogger<QueueWorker> logger, 
        IEnumerable<IMessageHandler> handlers
        )
    {
        _logger = logger;
        _handlers = handlers;
    }

    public void Dispose()
    {
        _logger.LogInformation("Request Dispose");

        _logger.LogInformation("Complete Dispose");
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Request Start");

        _logger.LogInformation("Complete Start");
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Request Stop");

        _logger.LogInformation("Complete Stop");
        return Task.CompletedTask;
    }
}
