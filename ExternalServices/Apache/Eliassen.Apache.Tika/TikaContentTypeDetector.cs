using Eliassen.Documents;
using java.io;
using System.IO;
using System.Threading.Tasks;

namespace Eliassen.Apache.Tika;

public class TikaContentTypeDetector : IContentTypeDetector
{
    public async Task<string?> DetectContentTypeAsync(Stream source)
    {
        var ms = new MemoryStream();
        await source.CopyToAsync(ms);
        ms.Position = 0;

        var input = new ByteArrayInputStream(ms.ToArray());

        var tika = new org.apache.tika.Tika();
        var contentType = tika.detect(input);
        return contentType;
    }
}
