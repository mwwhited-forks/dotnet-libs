using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Nucleus.Blog.Contracts.Collections
{
    [BsonIgnoreExtraElements]
    public class BlogCollection
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? BlogId { get; set; }

        [BsonElement("title")]
        public string? Title {  get; set; }
        [BsonElement("slug")]
        public string? Slug { get; set; }
        [BsonElement("tags")]
        public List<string?>? Tags { get; set; }
        [BsonElement("preview")]
        public string? Preview { get; set; }
        [BsonElement("content")]
        public string? Content { get; set; }
        [BsonElement("enabled")]
        public Boolean? Enabled { get; set; }
        [BsonElement("author")]
        public string? Author { get; set; }
        [BsonElement("createdOn")]
        public DateTimeOffset CreatedOn { get; set; }
    }
}
