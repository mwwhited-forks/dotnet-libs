using Eliassen.Documents.Conversion;
using java.io;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Eliassen.Apache.Tika;

/// <summary>
/// Provides a base class for document conversion handlers using Apache Tika.
/// </summary>
public abstract class TikaConversionHandlerBase : IDocumentConversionHandler
{
    /// <summary>
    /// Gets the parser instance used for document conversion.
    /// </summary>
    /// <returns>The parser instance.</returns>
    protected abstract org.apache.tika.parser.Parser Parser();

    /// <summary>
    /// Gets the content handler instance used for document conversion.
    /// </summary>
    /// <param name="output">The output stream for the converted document.</param>
    /// <returns>The content handler instance.</returns>
    protected abstract org.xml.sax.ContentHandler Handler(OutputStream output);

    /// <summary>
    /// Gets an array of supported destination content types for conversion.
    /// </summary>
    public abstract string[] Destinations { get; }

    /// <summary>
    /// Gets an array of supported source content types for conversion.
    /// </summary>
    public abstract string[] Sources { get; }

    /// <summary>
    /// Asynchronously converts a document from the source stream to the destination stream.
    /// </summary>
    /// <param name="source">The stream containing the source document.</param>
    /// <param name="sourceContentType">The content type of the source document.</param>
    /// <param name="destination">The stream to which the converted document will be written.</param>
    /// <param name="destinationContentType">The desired content type of the converted document.</param>
    /// <exception cref="NotSupportedException">
    /// Thrown when either the source content type or the destination content type is not supported.
    /// </exception>
    public async Task ConvertAsync(Stream source, string sourceContentType, Stream destination, string destinationContentType)
    {
        if (!SupportedSource(sourceContentType)) throw new NotSupportedException($"Source Content Type \"{sourceContentType}\" is not supported");
        if (!SupportedDestination(destinationContentType)) throw new NotSupportedException($"Source Content Type \"{destinationContentType}\" is not supported");

        var ms = new MemoryStream();
        await source.CopyToAsync(ms);
        ms.Position = 0;

        var input = new ByteArrayInputStream(ms.ToArray());
        var output = new ByteArrayOutputStream();
        try
        {
            Parser().parse(input, Handler(output), new(), new());
            destination.Write(output.toByteArray());
        }
        finally
        {
            input.close();
            output.close();
        }

        destination.Position = 0;
    }

    /// <summary>
    /// Checks if the specified content type is supported for conversion to a destination format.
    /// </summary>
    /// <param name="contentType">The content type to check.</param>
    /// <returns><c>true</c> if the content type is supported; otherwise, <c>false</c>.</returns>
    public bool SupportedDestination(string contentType) => Destinations.Any(t => string.Equals(t, contentType, StringComparison.OrdinalIgnoreCase));

    /// <summary>
    /// Checks if the specified content type is supported as a source format for conversion.
    /// </summary>
    /// <param name="contentType">The content type to check.</param>
    /// <returns><c>true</c> if the content type is supported; otherwise, <c>false</c>.</returns>
    public bool SupportedSource(string contentType) => Sources.Any(t => string.Equals(t, contentType, StringComparison.OrdinalIgnoreCase));

}
