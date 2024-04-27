using org.apache.tika.parser;
using org.apache.tika.parser.odf;

namespace Eliassen.Apache.Tika;

public class TikaOdtToHtmlConversionHandler : TikaToHtmlConversionBaseHandler
{
    protected override Parser Parser() => new OpenDocumentParser();

    public override string[] Sources => ["application/vnd.oasis.opendocument.text"];
}
