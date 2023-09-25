using Eliassen.System.Text.Json;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Text.Json.Serialization;

namespace Nucleus.Lesson.Contracts.Collections
{
    [BsonIgnoreExtraElements]
    public class LessonCollection
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonPropertyName("_id")]
        [JsonConverter(typeof(BsonIdConverter))]
        public string? LessonId { get; set; }

        public string? Title {  get; set; }
        public string? Slug { get; set; }
        public string? MediaLink { get; set; }
        public string? PreviewImage { get; set; }
        public string? Preview { get; set; }
        public string? Content { get; set; }
        public Boolean? Enabled { get; set; }
        [JsonConverter(typeof(BsonDateConverter))]
        public DateTimeOffset? CreatedOn { get; set; }
        public string[]? Attendees { get; set; }
        public string? Teacher { get; set; }
        public int? Duration { get; set; }
        public string[]? Tags { get; set; }
        public double Price { get; set; }
        public string[]? Goals { get; set; }
        [JsonConverter(typeof(BsonDateConverter))]
        public DateTimeOffset? StartDateTime { get; set; }
        [JsonConverter(typeof(BsonDateConverter))]
        public DateTimeOffset? EndDateTime { get; set; }
        public string? Notes { get; set; }
    }
}
