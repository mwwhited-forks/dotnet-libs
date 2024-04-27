using org.apache.tika.parser;
using org.apache.tika.parser.epub;

namespace Eliassen.Apache.Tika;

public class TikaEpubToHtmlConversionHandler : TikaToHtmlConversionBaseHandler
{
    protected override Parser Parser() => new EpubParser();

    public override string[] Sources => ["application/epub+zip"];
}

