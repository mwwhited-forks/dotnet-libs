using System.IO;

namespace Eliassen.Extensions.IO;

public static class StreamExtensions
{
    public static Stream CopyOf(this Stream stream)
    {
        var ms = new MemoryStream();
        stream.CopyTo(ms);
        ms.Position = 0;
        return ms;
    }
}
