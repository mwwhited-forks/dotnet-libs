using Eliassen.Documents.Conversion;
using java.io;
using org.apache.tika.metadata;
using org.apache.tika.parser;
using org.apache.tika.sax;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Eliassen.Apache.Tika;

/// <summary>
/// Converts  documents to HTML format.
/// </summary>
public class TikaDocxToHtmlConversionHandler : IDocumentConversionHandler
{
    /// <summary>
    /// Converts the content of a  document in the source stream to HTML format
    /// and writes it to the destination stream.
    /// </summary>
    /// <param name="source">The source stream containing the  document.</param>
    /// <param name="sourceContentType">The content type of the source stream.</param>
    /// <param name="destination">The destination stream where the HTML content will be written.</param>
    /// <param name="destinationContentType">The content type of the destination stream.</param>
    /// <returns>A task representing the asynchronous conversion operation.</returns>
    /// <exception cref="NotSupportedException">Thrown when either the source or destination content type is not supported.</exception>
    public async Task ConvertAsync(Stream source, string sourceContentType, Stream destination, string destinationContentType)
    {
        if (!SupportedSource(sourceContentType)) throw new NotSupportedException($"Source Content Type \"{sourceContentType}\" is not supported");
        if (!SupportedDestination(destinationContentType)) throw new NotSupportedException($"Source Content Type \"{destinationContentType}\" is not supported");

        var ms = new MemoryStream();
        await source.CopyToAsync(ms);
        ms.Position = 0;

        var inBuff = ms.ToArray();
        var input = new ByteArrayInputStream(inBuff);
        var output = new ByteArrayOutputStream();
        var metadata = new Metadata();
        var context = new ParseContext();
        try
        {
            var parser = new org.apache.tika.parser.microsoft.ooxml.OOXMLParser();
            var handler = new ToHTMLContentHandler(output, "UTF-8");
            parser.parse(input, handler, metadata, context);
            destination.Write(output.toByteArray());
        }
        finally
        {
            input.close();
            output.close();
        }

        destination.Position = 0;
    }

    // https://tika.apache.org/3.0.0-BETA/formats.html#HyperText_Markup_Language

    /// <summary>
    /// Gets the content types supported for the destination stream.
    /// </summary>
    public string[] Destinations => [
        "text/html", "text/xhtml", "text/xhtml+xml",
        ];

    /// <summary>
    /// Checks if the specified content type is supported for the destination stream.
    /// </summary>
    /// <param name="contentType">The content type to check.</param>
    /// <returns>True if the content type is supported; otherwise, false.</returns>
    public bool SupportedDestination(string contentType) => Destinations.Any(t => string.Equals(t, contentType, StringComparison.OrdinalIgnoreCase));

    /// <summary>
    /// Gets the content types supported for the source stream.
    /// </summary>
    public string[] Sources => [
        "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
        "application/msword"
    ];

    /// <summary>
    /// Checks if the specified content type is supported for the source stream.
    /// </summary>
    /// <param name="contentType">The content type to check.</param>
    /// <returns>True if the content type is supported; otherwise, false.</returns>
    public bool SupportedSource(string contentType) => Sources.Any(t => string.Equals(t, contentType, StringComparison.OrdinalIgnoreCase));
}
