using Eliassen.System.Templating;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Nucleus.TemplateEngine.Cli;

public class TemplateEngineService : IHostedService
{
    private readonly TemplateEngineSettings _settings;
    private readonly ITemplateEngine _engine;

    public TemplateEngineService(
        IOptions<TemplateEngineSettings> settings,
        ITemplateEngine engine
        )
    {
        _settings = settings.Value;
        _engine = engine;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {


        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
