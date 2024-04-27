using org.apache.tika.parser;
using org.apache.tika.parser.microsoft.ooxml;
using org.apache.tika.parser.odf;

namespace Eliassen.Apache.Tika;

public class TikaDocxToHtmlConversionHandler : TikaToHtmlConversionBaseHandler
{
    protected override Parser Parser() => new OOXMLParser();

    public override string[] Sources => [
        "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
        "application/x-tika-ooxml"
    ];
}
