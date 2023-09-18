using Eliassen.System.Text.Json;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Text.Json.Serialization;

namespace Nucleus.Lesson.Persistence.Collections
{
    [BsonIgnoreExtraElements]
    public class LessonScheduleCollection
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonPropertyName("_id")]
        [JsonConverter(typeof(BsonIdConverter))]
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
        [JsonConverter(typeof(BsonDateConverter))]
        public DateTimeOffset? CreatedOn { get; set; }

        [BsonElement("teacher")]
        public string? Teacher { get; set; }

        [BsonElement("duration")]
        public int? Duration { get; set; }

        [BsonElement("tags")]
        public string[]? Tags { get; set; }

        [BsonElement("price")]
        public double Price { get; set; }

        [BsonElement("goals")]
        public string[]? Goals { get; set; }

        [BsonElement("startDatetime")]
        [JsonConverter(typeof(BsonDateConverter))]
        public DateTimeOffset? StartDateTime { get; set; }

        [BsonElement("enddatetime")]
        [JsonConverter(typeof(BsonDateConverter))]
        public DateTimeOffset? EndDateTime { get; set; }

        [BsonElement("repeat")]
        public string? Repeat { get; set; }
    }
}
