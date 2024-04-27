using org.apache.tika.parser;
using org.apache.tika.parser.microsoft;

namespace Eliassen.Apache.Tika;

public class TikaDocToHtmlConversionHandler : TikaToHtmlConversionBaseHandler
{
    protected override Parser Parser() => new OfficeParser();

    public override string[] Sources => ["application/msword"];
}
