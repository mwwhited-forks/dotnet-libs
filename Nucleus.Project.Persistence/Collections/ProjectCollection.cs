using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Text.Json.Serialization;

namespace Nucleus.Project.Persistence.Collections
{
    [BsonIgnoreExtraElements]
    public class ProjectCollection
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonPropertyName("_id")]
        public string? ProjectId { get; set; }

        [BsonElement("title")]
        public string? Title { get; set; }
        [BsonElement("slug")]
        public string? Slug { get; set; }
        [BsonElement("projectLink")]
        public string? ProjectLink { get; set; }
        [BsonElement("projectImage")]
        public string? ProjectImage { get; set; }
        [BsonElement("preview")]
        public string? Preview { get; set; }
        [BsonElement("content")]
        public string? Content { get; set; }
        [BsonElement("page")]
        public string? Page { get; set; }
        [BsonElement("enabled")]
        public bool? Enabled { get; set; }
        [BsonElement("createdOn")]
        public DateTimeOffset CreatedOn { get; set; }
    }
}
