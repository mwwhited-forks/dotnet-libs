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
        //TODO: restore
#warning RESTORE THIS FEATURE
        //Task<DocumentModel?> GetDocumentAsync(DocumentsFilter filter);
        //TODO: restore
#warning RESTORE THIS FEATURE
        //Task<List<DocumentModel>?> GetDocumentsAsync(DocumentsFilter filter);
        Task CreateAsync(DocumentModel document);
        Task UpdateAsync(DocumentModel document);
        Task RemoveAsync(string id);
    }
}
