using org.apache.tika.parser;
using org.apache.tika.parser.pdf;

namespace Eliassen.Apache.Tika;

/// <summary>
/// Provides functionality to convert PDF documents to HTML using Apache Tika.
/// </summary>
public class TikaPdfToHtmlConversionHandler : TikaToHtmlConversionBaseHandler
{
    /// <summary>
    /// Gets the parser instance used for document conversion.
    /// </summary>
    /// <returns>The parser instance for PDF documents.</returns>
    protected override Parser Parser() => new PDFParser();

    /// <summary>
    /// Gets an array of supported source content types for conversion.
    /// </summary>
    public override string[] Sources => ["application/pdf"];
}
