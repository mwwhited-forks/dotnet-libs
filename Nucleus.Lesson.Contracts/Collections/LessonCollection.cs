using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;

namespace Nucleus.Lesson.Contracts.Collections
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

        [BsonElement("attendees")]
        public string[]? Attendees { get; set; }

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

        [BsonElement("startdatetime")]
        public DateTimeOffset StartDateTime { get; set; }

        [BsonElement("enddatetime")]
        public DateTimeOffset? EndDateTime { get; set; }
    }
}
