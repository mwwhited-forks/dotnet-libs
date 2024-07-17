using Eliassen.AI;
using Eliassen.System.Text.Templating;
using HandlebarsDotNet;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Graph.Models;
using OllamaSharp;
using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Eliassen.FileRagEngine.Cli;

public class FileRagEngineService : IHostedService
{
    private readonly ILogger _log;
    private readonly IOptions<FileRagEngineOptions> _settings;
    private readonly ITemplateEngine _engine;
    private readonly IServiceProvider _serviceProvider;

    public FileRagEngineService(
        ILogger<FileRagEngineService> log,
        IOptions<FileRagEngineOptions> settings,
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
#pragma warning disable CA2208 // Instantiate argument exceptions correctly
        if (string.IsNullOrWhiteSpace(_settings.Value.InputPath)) throw new ArgumentNullException(nameof(_settings.Value.InputPath));
        if (string.IsNullOrWhiteSpace(_settings.Value.Template)) throw new ArgumentNullException(nameof(_settings.Value.Template));
        if (string.IsNullOrWhiteSpace(_settings.Value.OutputPath)) throw new ArgumentNullException(nameof(_settings.Value.OutputPath));
#pragma warning restore CA2208 // Instantiate argument exceptions correctly

        //app starts here
        var inputPath = Path.GetFullPath(_settings.Value.InputPath);
        var outputPath = Path.GetFullPath(_settings.Value.OutputPath);

        // create a connection to ollama
        var client = GetProvider();

        // scan directories from application
        var directories = Directory.GetDirectories(inputPath, "*.*", SearchOption.AllDirectories);
        foreach (var directory in directories)
        {
            var realative = Path.GetFullPath(directory).Replace(inputPath + "\\", "");

            if (new[] { "bin", "obj" }.Contains(Path.GetFileName(directory)))
            {
                _log.LogWarning("skip path: {directory}", directory);
                continue;
            }

            _log.LogInformation("reading: {directory}", directory);

            var outFolder = Path.Combine(outputPath, realative);

            var files = Directory.GetFiles(directory);

            if (!files.Any())
            {
                _log.LogWarning("path empty: {directory}", directory);
                continue;
            }
            if (!Path.Exists(outFolder)) Directory.CreateDirectory(outFolder);

            var responseFileContent = Path.Combine(outFolder, _settings.Value.Template);
            var promptFile = Path.ChangeExtension(responseFileContent, ".prompt" + Path.GetExtension(responseFileContent));
            var responseFile = Path.ChangeExtension(responseFileContent, ".json");

            if (!File.Exists(responseFileContent))
            {
                var data = new { files = files.Select(file => new { name = Path.GetFileName(file), content = File.ReadAllText(file) }).ToArray(), };

                // per folder generate a prompt using handlebars
                _log.LogInformation("generate prompt: {directory}", directory);

                using var promptStream = new MemoryStream();
                var templateContext = await _engine.ApplyAsync(_settings.Value.Template, data, promptStream);
                promptStream.Position = 0;
                var promptReader = new StreamReader(promptStream);

                if (_settings.Value.IncludePrompt)
                {
                    await File.WriteAllBytesAsync(promptFile, promptStream.ToArray());
                }

                // post prompt to ollama
                _log.LogInformation("request completion: {directory}", directory);
                var response = await client.GetCompletionAsync(new() { Prompt = promptReader.ReadToEnd() });

                // capture response from ollama
                _log.LogInformation("write files: {directory}", directory);
                await File.WriteAllTextAsync(responseFileContent, response.Response);

                if (_settings.Value.IncludeRawOutput)
                {
                    using var responseStream = File.Create(responseFile);
                    await JsonSerializer.SerializeAsync(responseStream, response);
                    await responseStream.FlushAsync();
                }
            }
        }
    }

    private IMessageCompletion GetProvider() => _settings.Value.LanguageModelType switch
    {
        string key => _serviceProvider.GetKeyedService<IMessageCompletion>(_settings.Value.LanguageModelType),
        _ => _serviceProvider.GetService<IMessageCompletion>()
    } ?? throw new NotSupportedException($"No language model provider configured");

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
