using org.apache.tika.parser;
using org.apache.tika.parser.odf;

namespace Eliassen.Apache.Tika;


/// <summary>
/// Provides functionality to convert OpenDocument Text (ODT) documents to HTML using Apache Tika.
/// </summary>
public class TikaOdtToHtmlConversionHandler : TikaToHtmlConversionBaseHandler
{
    /// <summary>
    /// Gets the parser instance used for document conversion.
    /// </summary>
    /// <returns>The parser instance for OpenDocument Text (ODT) documents.</returns>
    protected override Parser Parser() => new OpenDocumentParser();

    /// <summary>
    /// Gets an array of supported source content types for conversion.
    /// </summary>
    public override string[] Sources => ["application/vnd.oasis.opendocument.text"];
}
