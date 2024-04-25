using DocumentFormat.OpenXml.Packaging;
using Eliassen.Documents.Conversion;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Xsl;

namespace Eliassen.Microsoft.OpenXml;

/// <summary>
/// Converts Docx documents to Markdown format.
/// </summary>
public class DocxToMarkdownConversionHandler : IDocumentConversionHandler
{
    /// <summary>
    /// Converts the content of a Docx document in the source stream to Markdown format
    /// and writes it to the destination stream.
    /// </summary>
    /// <param name="source">The source stream containing the Docx document.</param>
    /// <param name="sourceContentType">The content type of the source stream.</param>
    /// <param name="destination">The destination stream where the Markdown content will be written.</param>
    /// <param name="destinationContentType">The content type of the destination stream.</param>
    /// <returns>A task representing the asynchronous conversion operation.</returns>
    /// <exception cref="NotSupportedException">Thrown when either the source or destination content type is not supported.</exception>
    public async Task ConvertAsync(Stream source, string sourceContentType, Stream destination, string destinationContentType)
    {
        if (!SupportedSource(sourceContentType)) throw new NotSupportedException($"Source Content Type \"{sourceContentType}\" is not supported");
        if (!SupportedDestination(destinationContentType)) throw new NotSupportedException($"Source Content Type \"{destinationContentType}\" is not supported");

        var templateStream = GetType().Assembly.GetManifestResourceStream("Eliassen.Microsoft.OpenXml.docx2md.xslt");
        var templateReader = XmlReader.Create(templateStream);

        var xslt = new XslCompiledTransform(); xslt.Load(templateReader, new XsltSettings(true, true), XmlResolver.ThrowingResolver);

        using var doc = WordprocessingDocument.Open(source, false);
        var stream = doc.MainDocumentPart.GetStream();
        var reader = XmlReader.Create(stream, new()
        {
            CloseInput = false
        });

        var writer = XmlWriter.Create(destination, new()
        {
            CloseOutput = false,
            ConformanceLevel = ConformanceLevel.Auto,
        });

        destination.Position = 0;

        xslt.Transform(reader, writer);
    }

    /// <summary>
    /// Gets the content types supported for the destination stream.
    /// </summary>
    public string[] Destinations => ["text/markdown", "text/x-markdown", "text/plain"];

    /// <summary>
    /// Checks if the specified content type is supported for the destination stream.
    /// </summary>
    /// <param name="contentType">The content type to check.</param>
    /// <returns>True if the content type is supported; otherwise, false.</returns>
    public bool SupportedDestination(string contentType) => Destinations.Any(t => string.Equals(t, contentType, StringComparison.OrdinalIgnoreCase));

    /// <summary>
    /// Gets the content types supported for the source stream.
    /// </summary>
    public string[] Sources => ["application/vnd.openxmlformats-officedocument.wordprocessingml.document"];

    /// <summary>
    /// Checks if the specified content type is supported for the source stream.
    /// </summary>
    /// <param name="contentType">The content type to check.</param>
    /// <returns>True if the content type is supported; otherwise, false.</returns>
    public bool SupportedSource(string contentType) => Sources.Any(t => string.Equals(t, contentType, StringComparison.OrdinalIgnoreCase));
}
