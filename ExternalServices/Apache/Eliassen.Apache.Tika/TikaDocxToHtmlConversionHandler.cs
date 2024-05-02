using org.apache.tika.parser;
using org.apache.tika.parser.microsoft.ooxml;

namespace Eliassen.Apache.Tika;

/// <summary>
/// Provides functionality to convert Microsoft Word (DOCX) documents to HTML using Apache Tika.
/// </summary>
public class TikaDocxToHtmlConversionHandler : TikaToHtmlConversionBaseHandler
{
    /// <summary>
    /// Gets the parser instance used for document conversion.
    /// </summary>
    /// <returns>The parser instance for Office Open XML documents (DOCX).</returns>
    protected override Parser Parser() => new OOXMLParser();

    /// <summary>
    /// Gets an array of supported source content types for conversion.
    /// </summary>
    public override string[] Sources => [
        "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
        "application/x-tika-ooxml"
    ];
}
