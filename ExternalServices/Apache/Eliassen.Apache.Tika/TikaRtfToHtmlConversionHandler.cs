using org.apache.tika.parser;
using org.apache.tika.parser.microsoft.rtf;

namespace Eliassen.Apache.Tika;

/// <summary>
/// Provides functionality to convert Rich Text Format (RTF) documents to HTML using Apache Tika.
/// </summary>
public class TikaRtfToHtmlConversionHandler : TikaToHtmlConversionBaseHandler
{
    /// <summary>
    /// Gets the parser instance used for document conversion.
    /// </summary>
    /// <returns>The parser instance for Rich Text Format (RTF) documents.</returns>
    protected override Parser Parser() => new RTFParser();

    /// <summary>
    /// Gets an array of supported source content types for conversion.
    /// </summary>
    public override string[] Sources => ["application/rtf"];
}
