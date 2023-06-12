using Nucleus.Core.Persistence.Models;
using Nucleus.Core.Persistence.Models.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nucleus.Core.Persistence.Interfaces
{
    public interface IDocumentService
    {
#warning retire this
        Task<DocumentModel?> GetDocumentAsync(DocumentsFilter filter);
#warning retire this
        Task<List<DocumentModel>?> GetDocumentsAsync(DocumentsFilter filter);
        Task CreateAsync(DocumentModel document);
        Task UpdateAsync(DocumentModel document);
        Task RemoveAsync(string id);
    }
}
