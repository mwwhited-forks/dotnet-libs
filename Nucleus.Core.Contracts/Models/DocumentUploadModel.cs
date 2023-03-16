using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleus.Core.Contracts.Models
{
    public class DocumentUploadModel: DocumentModel
    {
        public byte[]? Data { get; set; }
    }
}
