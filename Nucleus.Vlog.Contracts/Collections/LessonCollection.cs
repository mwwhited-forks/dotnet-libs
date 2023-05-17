using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;

namespace Nucleus.Vlog.Contracts.Collections
{
    [BsonIgnoreExtraElements]
    public class LessonCollection
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? LessonId { get; set; }

        [BsonElement("title")]
        public string? Title {  get; set; }
        [BsonElement("slug")]
        public string? Slug { get; set; }
        [BsonElement("mediaLink")]
        public string? MediaLink { get; set; }
        [BsonElement("previewImage")]
        public string? PreviewImage { get; set; }
        [BsonElement("preview")]
        public string? Preview { get; set; }
        [BsonElement("content")]
        public string? Content { get; set; }
        [BsonElement("enabled")]
        public Boolean? Enabled { get; set; }
        [BsonElement("createdOn")]
        public DateTimeOffset CreatedOn { get; set; }
    }
}
