using Nucleus.Core.Contracts.Models;
using Nucleus.Core.Contracts.Models.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Nucleus.Core.Contracts.Managers
{
    public interface IDocumentManager
    {
        //TODO: restore
#warning RESTORE THIS FEATURE
        //Task<DocumentModel?> GetDocument(DocumentsFilter filter);

        //TODO: restore
#warning RESTORE THIS FEATURE
        //Task<List<DocumentModel>?> GetDocuments(DocumentsFilter filter);

        Task<BlobDto?> DownloadDocument(string DocumentName);

        Task<ResponseModel<DocumentModel?>> SaveDocument(DocumentModel document, Stream content);

        Task<ResponseModel<Boolean>> RemoveDocument(string id);
    }
}
