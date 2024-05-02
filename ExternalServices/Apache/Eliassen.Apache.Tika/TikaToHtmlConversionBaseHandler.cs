using java.io;
using org.apache.tika.sax;
using org.xml.sax;

namespace Eliassen.Apache.Tika;

/// <summary>
/// Provides a base class for handlers that convert documents to HTML using Apache Tika.
/// </summary>
public abstract class TikaToHtmlConversionBaseHandler : TikaConversionHandlerBase
{
    /// <summary>
    /// Gets the content handler instance used for document conversion to HTML.
    /// </summary>
    /// <param name="output">The output stream for the converted HTML.</param>
    /// <returns>The content handler instance.</returns>
    protected override ContentHandler Handler(OutputStream output) => new ToHTMLContentHandler(output, "UTF-8");

    /// <summary>
    /// Gets an array of supported destination content types for conversion.
    /// </summary>
    public override string[] Destinations => ["text/html", "text/xhtml", "text/xhtml+xml",];
}
