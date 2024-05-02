using org.apache.tika.parser;
using org.apache.tika.parser.microsoft;

namespace Eliassen.Apache.Tika;

/// <summary>
/// Provides functionality to convert Microsoft Word documents to HTML using Apache Tika.
/// </summary>
public class TikaDocToHtmlConversionHandler : TikaToHtmlConversionBaseHandler
{
    /// <summary>
    /// Gets the parser instance used for document conversion.
    /// </summary>
    /// <returns>The parser instance for Microsoft Office documents.</returns>
    protected override Parser Parser() => new OfficeParser();

    /// <summary>
    /// Gets an array of supported source content types for conversion.
    /// </summary>
    public override string[] Sources => ["application/msword"];
}
