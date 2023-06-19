using Eliassen.System.Templating;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text.Json;
using System.Xml.Linq;

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
        if (string.IsNullOrWhiteSpace(_settings.InputFile)) throw new ArgumentNullException(nameof(_settings.InputFile));
        if (string.IsNullOrWhiteSpace(_settings.TemplateFile)) throw new ArgumentNullException(nameof(_settings.TemplateFile));
        if (string.IsNullOrWhiteSpace(_settings.OutputFile)) throw new ArgumentNullException(nameof(_settings.OutputFile));

        var contentType = GetFileType(_settings.InputFileType, _settings.InputFile) ??
            throw new NotSupportedException(@$"""{_settings.InputFile}"" => ""{_settings.InputFileType}""");
        var content = GetContent(_settings.InputFile) ??
            throw new NotSupportedException("No content found");
        var data = GetData(contentType, content);

        _log.LogInformation($"Loaded: {{{nameof(_settings.InputFile)}}}", _settings.InputFile);

        var result = _engine.Apply("Service-Endpoints", null, data);

        _log.LogInformation($"Built: {{{nameof(_settings.TemplateFile)}}}", _settings.TemplateFile);

        var dir = Path.GetDirectoryName(_settings.OutputFile);
        if (dir != null && !Directory.Exists(dir)) Directory.CreateDirectory(dir);
        await File.WriteAllTextAsync(_settings.OutputFile, result);

        _log.LogInformation($"Written: {{{nameof(_settings.OutputFile)}}}", _settings.OutputFile);
    }

    private string? GetContent(string fileName) => File.Exists(fileName) ? File.ReadAllText(fileName) : null;
    private FileTypes? GetFileType(FileTypes? fileTypes, string fileName) =>
       fileTypes ?? Path.GetExtension(fileName)?.ToLowerInvariant() switch
       {
           ".json" => FileTypes.Json,
           ".xml" => FileTypes.Xml,
           _ => null
       };

    private object? GetData(FileTypes type, string content) =>
        type switch
        {
            FileTypes.Json => JsonDocument.Parse(content),
            FileTypes.Xml => XDocument.Parse(content),
            _ => null,
        };

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
