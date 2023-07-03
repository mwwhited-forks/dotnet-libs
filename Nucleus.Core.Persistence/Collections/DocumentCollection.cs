using Eliassen.System.Text.Json;
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

    [BsonElement("documentKey")]
    public string? DocumentKey { get; set; }

    [BsonElement("documentName")]
    public string? DocumentName { get; set; }

    [BsonElement("documentType")]
    public string? DocumentType { get; set; }

    [BsonElement("documentSize")]
    public int? documentSize { get; set; }

    [BsonElement("documentRepository")]
    public string? DocumentRepository { get; set; }

    [BsonElement("documentCategory")]
    public string? DocumentCategory { get; set; }

    [BsonElement("createdOn")]
    public DateTimeOffset? CreatedOn { get; set; }
}
