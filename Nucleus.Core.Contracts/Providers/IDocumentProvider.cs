using Nucleus.Core.Persistence.Models;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Nucleus.Core.Persistence.Providers
{
    public interface IDocumentProvider
    {
        Task<List<BlobDto>> ListAsync();
        Task<BlobResponseDto> UploadAsync(DocumentModel document, Stream content);
        Task<BlobDto?> DownloadAsync(string blobFilename);
        Task<BlobResponseDto> DeleteAsync(string blobFilename);
    }
}
