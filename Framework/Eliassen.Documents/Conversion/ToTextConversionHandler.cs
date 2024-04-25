using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Eliassen.Documents.Conversion;

/// <summary>
/// Represents a conversion handler for converting documents to text format.
/// </summary>
public class ToTextConversionHandler : IDocumentConversionHandler
{
    /// <summary>
    /// Converts the content of the source stream to text format and writes it to the destination stream asynchronously.
    /// </summary>
    /// <param name="source">The source stream containing the document content.</param>
    /// <param name="sourceContentType">The content type of the source document.</param>
    /// <param name="destination">The destination stream where the converted text will be written.</param>
    /// <param name="destinationContentType">The content type of the destination format (text).</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task ConvertAsync(Stream source, string sourceContentType, Stream destination, string destinationContentType)
    {
        if (!SupportedSource(sourceContentType)) throw new NotSupportedException($"Source Content Type \"{sourceContentType}\" is not supported");
        if (!SupportedDestination(destinationContentType)) throw new NotSupportedException($"Source Content Type \"{destinationContentType}\" is not supported");

        await source.CopyToAsync(destination);
    }

    /// <summary>
    /// Array of supported destination content types (text/plain).
    /// </summary>
    public string[] Destinations => ["text/plain"];

    /// <summary>
    /// Checks if the provided content type is supported as a destination format (text/plain).
    /// </summary>
    /// <param name="contentType">The content type to check.</param>
    /// <returns>True if the content type is supported; otherwise, false.</returns>
    public bool SupportedDestination(string contentType) => Destinations.Any(t => string.Equals(t, contentType, StringComparison.OrdinalIgnoreCase));

    /// <summary>
    /// Array of supported source content types (application/octet-stream).
    /// </summary>
    public string[] Sources => ["application/octet-stream"];

    /// <summary>
    /// Checks if the provided content type is supported as a source format (any content type is supported).
    /// </summary>
    /// <param name="contentType">The content type to check.</param>
    /// <returns>Always returns true because any content type is supported as a source format.</returns>
    public bool SupportedSource(string contentType) => true; // Sources.Any(t => string.Equals(t, contentType, StringComparison.OrdinalIgnoreCase));
}
