using Eliassen.System.Text.Json;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Nucleus.Blog.Persistence.Collections
{
    [BsonIgnoreExtraElements]
    public class BlogCollection
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonPropertyName("_id")]
        [JsonConverter(typeof(BsonIdConverter))]
        public string? BlogId { get; set; }
        public string? Title { get; set; }
        public string? Slug { get; set; }
        public List<string?>? Tags { get; set; }
        public string? Preview { get; set; }
        public string? Content { get; set; }
        public bool? Enabled { get; set; }
        public string? Author { get; set; }

        [JsonConverter(typeof(BsonDateConverter))]
        public DateTimeOffset CreatedOn { get; set; }
    }
}
