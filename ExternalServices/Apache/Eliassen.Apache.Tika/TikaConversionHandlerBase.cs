using Eliassen.Documents.Conversion;
using java.io;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Eliassen.Apache.Tika;

public abstract class TikaConversionHandlerBase : IDocumentConversionHandler
{
    protected abstract org.apache.tika.parser.Parser Parser();
    protected abstract org.xml.sax.ContentHandler Handler(OutputStream output);
    public abstract string[] Destinations { get; }
    public abstract string[] Sources { get; }

    public async Task ConvertAsync(Stream source, string sourceContentType, Stream destination, string destinationContentType)
    {
        if (!SupportedSource(sourceContentType)) throw new NotSupportedException($"Source Content Type \"{sourceContentType}\" is not supported");
        if (!SupportedDestination(destinationContentType)) throw new NotSupportedException($"Source Content Type \"{destinationContentType}\" is not supported");

        var ms = new MemoryStream();
        await source.CopyToAsync(ms);
        ms.Position = 0;

        var input = new ByteArrayInputStream(ms.ToArray());
        var output = new ByteArrayOutputStream();
        try
        {
            Parser().parse(input, Handler(output), new(), new());
            destination.Write(output.toByteArray());
        }
        finally
        {
            input.close();
            output.close();
        }

        destination.Position = 0;
    }

    public bool SupportedDestination(string contentType) => Destinations.Any(t => string.Equals(t, contentType, StringComparison.OrdinalIgnoreCase));
    public bool SupportedSource(string contentType) => Sources.Any(t => string.Equals(t, contentType, StringComparison.OrdinalIgnoreCase));

}
