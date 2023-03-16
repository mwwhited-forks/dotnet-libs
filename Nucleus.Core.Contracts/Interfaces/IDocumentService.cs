using Nucleus.Core.Contracts.Collections;
using Nucleus.Core.Contracts.Models.Filters;
using Nucleus.Core.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nucleus.Core.Contracts.Interfaces
{
    public interface IDocumentService
    {
        Task<DocumentModel?> GetDocumentAsync(DocumentsFilter filter);
        Task<List<DocumentModel>?> GetDocumentsAsync(DocumentsFilter filter);
        Task CreateAsync(DocumentModel document);
        Task UpdateAsync(DocumentModel document);
        Task RemoveAsync(string id);
    }
}
