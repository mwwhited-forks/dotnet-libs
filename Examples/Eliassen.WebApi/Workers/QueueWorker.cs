
namespace Eliassen.WebApi.Workers;

public class QueueWorker : IHostedService, IDisposable
{
    private readonly ILogger _logger;


    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
