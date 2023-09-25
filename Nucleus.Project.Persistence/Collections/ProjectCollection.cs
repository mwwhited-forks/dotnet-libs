using Eliassen.System.Text.Json;
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
        [JsonConverter(typeof(BsonIdConverter))]
        public string? ProjectId { get; set; }
        public string? Title { get; set; }
        public string? Slug { get; set; }
        public string? ProjectLink { get; set; }
        public string? ProjectImage { get; set; }
        public string? Preview { get; set; }
        public string? Content { get; set; }
        public string? Page { get; set; }
        public bool? Enabled { get; set; }
        [JsonConverter(typeof(BsonDateConverter))]
        public DateTimeOffset CreatedOn { get; set; }
    }
}
