using System.IO;
using System.Threading.Tasks;

namespace Eliassen.Apache.Tika;

public interface IApacheTikaClient
{
    public ValueTask<string> DetectStreamAsync(Stream source);
    Task ConvertAsync(Stream source, string sourceContentType, Stream destination, string destinationContentType);
}
