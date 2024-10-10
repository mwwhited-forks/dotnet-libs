using Eliassen.Documents;
using Eliassen.Documents.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
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
        var sourceFileType =
            _documentTypes.FirstOrDefault(ft => ft.FileExtensions.Any(e => string.Equals(e, Path.GetExtension(_settings.Value.InputPath), StringComparison.OrdinalIgnoreCase)))
            ?.ContentTypes[0] ?? throw new ApplicationException("Unable to identify input file type")
            ;
        var targetFileType =
            _documentTypes.FirstOrDefault(ft => ft.FileExtensions.Any(e => string.Equals(e, Path.GetExtension(_settings.Value.OutputPath), StringComparison.OrdinalIgnoreCase)))
            ?.ContentTypes[0] ?? throw new ApplicationException("Unable to identify output file type")
            ;

        _log.LogInformation("convert \"{sourceFileType}\" to \"{targetFileType}\" \"{inFile}\"", sourceFileType, targetFileType, Path.GetFileName(_settings.Value.InputPath));

        var sourcePath = _settings.Value.InputPath ?? throw new ApplicationException("Must provide input path");

        if (!Path.Exists(sourcePath)) throw new ApplicationException("File not found");

        using var source = new MemoryStream();
        using var sourceFile = File.OpenRead(sourcePath);
        await sourceFile.CopyToAsync(source, cancellationToken);
        source.Position = 0;

        using var target = new MemoryStream();
        if (await _documentConversion.ConvertAsync(source, sourceFileType, target, targetFileType))
        {
            await using var targetOut = File.Create(_settings.Value.OutputPath ?? throw new ApplicationException("Must provide output path"));

            _log.LogInformation("converted \"{sourceFileType}\" to \"{targetFileType}\" \"{outFile}\"", sourceFileType, targetFileType, Path.GetFileName(_settings.Value.OutputPath));
            await target.CopyToAsync(targetOut, cancellationToken);
            await targetOut.FlushAsync(cancellationToken);
            targetOut.Close();
        }
        else
        {
            _log.LogInformation("no conversion \"{sourceFileType}\" to \"{targetFileType}\"", sourceFileType, targetFileType);
        }
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
