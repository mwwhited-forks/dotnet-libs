using java.io;
using org.apache.tika.sax;
using org.xml.sax;

namespace Eliassen.Apache.Tika;

public abstract class TikaToHtmlConversionBaseHandler : TikaConversionHandlerBase
{
    protected override ContentHandler Handler(OutputStream output) => new ToHTMLContentHandler(output, "UTF-8");
    public override string[] Destinations => ["text/html", "text/xhtml", "text/xhtml+xml",];
}
