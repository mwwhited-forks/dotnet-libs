using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Eliassen.Documents.Conversion;

/// <summary>
/// Represents a document conversion service.
/// </summary>
public class DocumentConversion : IDocumentConversion
{
    private readonly IDocumentConversionChainBuilder _chain;
    private readonly ILogger _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="DocumentConversion"/> class with the specified document conversion chain builder.
    /// </summary>
    /// <param name="chain">The document conversion chain builder.</param>
    /// <param name="logger">The logger.</param>
    public DocumentConversion(
        IDocumentConversionChainBuilder chain,
        ILogger<DocumentConversion> logger
        )
    {
        _chain = chain;
        _logger = logger;
    }

    private readonly Dictionary<(string source, string destination), ChainStep[]> _cache = [];

    /// <summary>
    /// Converts the content of a source stream to a destination stream asynchronously.
    /// </summary>
    /// <param name="source">The source stream containing the content to be converted.</param>
    /// <param name="sourceContentType">The content type of the source content.</param>
    /// <param name="destination">The destination stream where the converted content will be written.</param>
    /// <param name="destinationContentType">The content type of the converted content.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task ConvertAsync(Stream source, string sourceContentType, Stream destination, string destinationContentType)
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(sourceContentType, nameof(sourceContentType));
        ArgumentNullException.ThrowIfNull(destination, nameof(destination));
        ArgumentNullException.ThrowIfNull(destinationContentType, nameof(destinationContentType));

        if (string.Equals(sourceContentType, destinationContentType, StringComparison.OrdinalIgnoreCase))
            await source.CopyToAsync(destination);

        ChainStep[] steps;
        if (_cache.TryGetValue((sourceContentType, destinationContentType), out var cached))
        {
            _logger.LogInformation("Use cached chain {source} -> {destination}", sourceContentType, destinationContentType);
            steps = cached;
        }
        else
        {
            _logger.LogInformation("Build chain {source} -> {destination}", sourceContentType, destinationContentType);
            steps = _chain.Steps(sourceContentType, destinationContentType);
            _cache.TryAdd((sourceContentType, destinationContentType), steps);
        }

        _logger.LogInformation(
            "Chain {source} -> {destination} [{steps}]",
            sourceContentType, destinationContentType,
            string.Join(';', steps.Select(s => s.Handler))
            );

        if (steps.Length == 0) throw new NotSupportedException($"Conversion from \"{sourceContentType}\" to \"{destinationContentType}\" is not supported");
        else if (steps.Length == 1) await steps[0].Handler.ConvertAsync(source, sourceContentType, destination, destinationContentType);
        else
        {
            MemoryStream? temp = null;
            foreach (var step in steps)
            {
                temp = new MemoryStream();
                await step.Handler.ConvertAsync(source, step.SourceContentType, temp, step.DestinationContentType);
                temp.Position = 0;
                source = temp;
            }
            await (temp ?? source).CopyToAsync(destination);
            destination.Position = 0;
        }
    }
}

