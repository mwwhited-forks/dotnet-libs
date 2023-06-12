using Nucleus.Core.Persistence.Models;
using Nucleus.Core.Persistence.Models.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Nucleus.Core.Persistence.Managers
{
    public interface IDocumentManager
    {
#warning retire this
        Task<DocumentModel?> GetDocument(DocumentsFilter filter);
#warning retire this
        Task<List<DocumentModel>?> GetDocuments(DocumentsFilter filter);

        Task<BlobDto?> DownloadDocument(string DocumentName);

        Task<ResponseModel<DocumentModel?>> SaveDocument(DocumentModel document, Stream content);

        Task<ResponseModel<Boolean>> RemoveDocument(string id);
    }
}
