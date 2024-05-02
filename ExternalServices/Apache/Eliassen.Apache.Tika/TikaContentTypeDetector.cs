using Eliassen.Documents;
using java.io;
using System.IO;
using System.Threading.Tasks;

namespace Eliassen.Apache.Tika;

/// <summary>
/// Provides functionality to detect the content type of a stream using Apache Tika.
/// </summary>
public class TikaContentTypeDetector : IContentTypeDetector
{
    /// <summary>
    /// Asynchronously detects the content type of the provided stream using Apache Tika.
    /// </summary>
    /// <param name="source">The stream whose content type needs to be detected.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous operation. The task result
    /// contains the detected content type as a string, or <c>null</c> if the content type cannot be determined.
    /// </returns>
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
