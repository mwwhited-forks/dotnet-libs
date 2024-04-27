using org.apache.tika.parser;
using org.apache.tika.parser.pdf;

namespace Eliassen.Apache.Tika;

public class TikaPdfToHtmlConversionHandler : TikaToHtmlConversionBaseHandler
{
    protected override Parser Parser() => new PDFParser();

    public override string[] Sources => ["application/pdf"];
}
