using System.IO;
using System.Threading.Tasks;

namespace Eliassen.Documents;

public interface IContentTypeDetector
{
    Task<string?> DetectContentTypeAsync(Stream source);
}
