using Eliassen.Documents;
using Eliassen.Documents.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Eliassen.DocumentConverter.Cli;

public class DocumentConverterService : IHostedService
{
    private readonly ILogger _log;
    private readonly IOptions<DocumentConverterOptions> _settings;
    private readonly IDocumentConversion _documentConversion;
    private readonly IEnumerable<IDocumentType> _documentTypes;

    public DocumentConverterService(
        ILogger<DocumentConverterService> log,
        IOptions<DocumentConverterOptions> settings,
        IDocumentConversion documentConversion,
        IEnumerable<IDocumentType> documentTypes
        )
    {
        _log = log;
        _settings = settings;
        _documentConversion = documentConversion;
        _documentTypes = documentTypes;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var sourceFileType = _documentTypes.FirstOrDefault(ft => ft.FileExtensions.Any(e => string.Equals(e, Path.GetExtension(_settings.Value.InputPath), StringComparison.OrdinalIgnoreCase)));
        var targetFileType = _documentTypes.FirstOrDefault(ft => ft.FileExtensions.Any(e => string.Equals(e, Path.GetExtension(_settings.Value.OutputPath), StringComparison.OrdinalIgnoreCase)));

        _log.LogInformation(
            "convert \"{sourceFileType}\" to \"{targetFileType}\" \"{inFile}\"", 
            sourceFileType.ContentTypes[0],
            targetFileType.ContentTypes[0],
            Path.GetFileName(_settings.Value.InputPath)
            );

        using var source = new MemoryStream();
        using var sourceFile = File.OpenRead(_settings.Value.InputPath);

        using var target = new MemoryStream();
        if (await _documentConversion.ConvertAsync(source, sourceFileType.ContentTypes[0], target, targetFileType.ContentTypes[0]))
        {
            await using var targetOut = File.Create(_settings.Value.OutputPath);

            _log.LogInformation(
                "converted \"{sourceFileType}\" to \"{targetFileType}\" \"{outFile}\"", 
                sourceFileType.ContentTypes[0],
                targetFileType.ContentTypes[0], 
                Path.GetFileName(_settings.Value.OutputPath)
                );
            await target.CopyToAsync(targetOut);
        }
        else
        {
            _log.LogInformation(
                "no conversion \"{sourceFileType}\" to \"{targetFileType}\"",
                sourceFileType.ContentTypes[0],
                targetFileType.ContentTypes[0]
                );
        }
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
