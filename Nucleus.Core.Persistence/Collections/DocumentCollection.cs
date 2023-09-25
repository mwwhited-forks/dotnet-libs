<<<<<<< HEAD
﻿using Eliassen.System.Text.Json;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Text.Json.Serialization;

namespace Nucleus.Core.Persistence.Collections;

[BsonIgnoreExtraElements]
public class DocumentCollection
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [JsonPropertyName("_id")]
    [JsonConverter(typeof(BsonIdConverter))]
    public string? DocumentId { get; set; }

    public string? DocumentKey { get; set; }
    public string? DocumentName { get; set; }
    public string? DocumentType { get; set; }
    public int? documentSize { get; set; }
    public string? DocumentRepository { get; set; }
    public string? DocumentCategory { get; set; }
    [JsonConverter(typeof(BsonDateConverter))]
    public DateTimeOffset? CreatedOn { get; set; }
}
=======
﻿using System;

namespace Nucleus.Core.Persistence.Collections
{
    public class DocumentCollection
    {
        public string? DocumentId { get; set; }

        public string? DocumentKey { get; set; }
        public string? DocumentName { get; set; }
        public string? DocumentType { get; set; }
        public int? documentSize { get; set; }
        public string? DocumentRepository { get; set; }
        public string? DocumentCategory { get; set; }
        public DateTimeOffset? CreatedOn { get; set; }
    }
}
>>>>>>> 42f4ded (fixup id conventions for bson)
