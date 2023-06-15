using Eliassen.System.Templating;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace Nucleus.TemplateEngine.Cli;

public class TemplateEngineService : IHostedService
{
    private readonly ILogger _log;
    private readonly TemplateEngineSettings _settings;
    private readonly ITemplateEngine _engine;

    public TemplateEngineService(
        ILogger<TemplateEngineService> log,
        IOptions<TemplateEngineSettings> settings,
        ITemplateEngine engine
        )
    {
        _log = log;
        _settings = settings.Value;
        _engine = engine;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var swaggerjson = @"D:\Repos\Nu2\NetApi\docs\swagger.json";
        var json = File.ReadAllText(swaggerjson);
        var data = JsonDocument.Parse(json);

        _log.LogInformation($"Loaded: {{file}}", swaggerjson);

        var result = _engine.Apply("Service", "Endpoints", data);

        _log.LogInformation($"Built: {{file}}", swaggerjson);

        var file = Path.Combine("output", _engine.SuggestedFileName("Service", "Endpoints"));
        if (!Directory.Exists("output")) Directory.CreateDirectory("output");
        await File.WriteAllTextAsync(file, result);

        _log.LogInformation($"Written: {{file}}", file);
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
