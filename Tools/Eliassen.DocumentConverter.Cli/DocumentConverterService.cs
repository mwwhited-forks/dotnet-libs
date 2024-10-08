using Eliassen.System.Text.Templating;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Eliassen.DocumentConverter.Cli;

public class DocumentConverterService : IHostedService
{
    private readonly ILogger _log;
    private readonly IOptions<DocumentConverterOptions> _settings;
    private readonly ITemplateEngine _engine;
    private readonly IServiceProvider _serviceProvider;

    public DocumentConverterService(
        ILogger<DocumentConverterService> log,
        IOptions<DocumentConverterOptions> settings,
        ITemplateEngine engine,
        IServiceProvider serviceProvider
        )
    {
        _log = log;
        _settings = settings;
        _engine = engine;
        _serviceProvider = serviceProvider;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
