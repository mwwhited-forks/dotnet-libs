<<<<<<< HEAD
﻿using Eliassen.System.Text.Json;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Text.Json.Serialization;
=======
﻿using System;
using System.ComponentModel.DataAnnotations;
>>>>>>> 42f4ded (fixup id conventions for bson)

namespace Nucleus.Project.Persistence.Collections
{
    public class ProjectCollection
    {
<<<<<<< HEAD
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonPropertyName("_id")]
        [JsonConverter(typeof(BsonIdConverter))]
=======
>>>>>>> 42f4ded (fixup id conventions for bson)
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
