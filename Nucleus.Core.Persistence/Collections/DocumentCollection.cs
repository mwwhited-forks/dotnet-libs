using Eliassen.System.Text.Json;
using System;
using System.Text.Json.Serialization;

namespace Nucleus.Core.Persistence.Collections;

[CollectionName("documents")]
public class DocumentCollectiong
{
    [Key]
    public string? DocumentId { get; set; }

    public string? DocumentKey { get; set; }
    public string? DocumentName { get; set; }
    public string? DocumentType { get; set; }
    public int? documentSize { get; set; }
    public string? DocumentRepository { get; set; }
    public string? DocumentCategory { get; set; }
    public DateTimeOffset? CreatedOn { get; set; }
}
