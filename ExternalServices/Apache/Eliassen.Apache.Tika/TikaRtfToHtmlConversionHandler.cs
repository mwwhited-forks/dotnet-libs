using org.apache.tika.parser;
using org.apache.tika.parser.microsoft.rtf;

namespace Eliassen.Apache.Tika;

public class TikaRtfToHtmlConversionHandler : TikaToHtmlConversionBaseHandler
{
    protected override Parser Parser() => new RTFParser();

    public override string[] Sources => ["application/rtf"];
}
