using Eliassen.System.Text.Templating;
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
        if (string.IsNullOrWhiteSpace(_settings.Template)) throw new ArgumentNullException(nameof(_settings.Template));
        if (string.IsNullOrWhiteSpace(_settings.OutputFile)) throw new ArgumentNullException(nameof(_settings.OutputFile));

        var inputPath = Path.GetFullPath(Path.GetDirectoryName(_settings.InputFile) ?? ".");
        var inputFile = Path.GetFileName(_settings.InputFile);

        foreach (var file in Directory.EnumerateFiles(inputPath, inputFile))
        {
            var contentType = GetFileType(_settings.InputFileType, file) ??
                throw new NotSupportedException(@$"""{file}"" => ""{_settings.InputFileType}""");
            var content = GetContent(file) ??
                throw new NotSupportedException($"No content found: \"{file}\"");
            var data = GetData(contentType, content) ??
                throw new NotSupportedException($"No data found: ({contentType}:{content?.Length})"); ;

            _log.LogInformation(
                $"Loaded: {{{nameof(file)}}} for {{{nameof(_settings.Template)}}}",
                _settings.InputFile,
                _settings.Template
                );

            var outFile = _settings.OutputFile
                .Replace("[file]", Path.GetFileNameWithoutExtension(file), StringComparison.InvariantCultureIgnoreCase)
                ;
            var dir = Path.GetDirectoryName(outFile);
            if (dir != null && !Directory.Exists(dir)) Directory.CreateDirectory(dir);
            using var fileWriter = File.Open(outFile, FileMode.Create, FileAccess.Write, FileShare.Read);

            var result = await _engine.ApplyAsync(_settings.Template, data, fileWriter);
            await fileWriter.FlushAsync();
            _log.LogInformation($"Written: {{{nameof(outFile)}}}", outFile);
        }
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
