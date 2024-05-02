using org.apache.tika.parser;
using org.apache.tika.parser.epub;

namespace Eliassen.Apache.Tika;

public class TikaEpubToHtmlConversionHandler : TikaToHtmlConversionBaseHandler
{
    /// <summary>
    /// Gets the parser instance used for document conversion.
    /// </summary>
    /// <returns>The parser instance for EPUB documents.</returns>
    protected override Parser Parser() => new EpubParser();

    /// <summary>
    /// Gets an array of supported source content types for conversion.
    /// </summary>
    public override string[] Sources => ["application/epub+zip"];
}

