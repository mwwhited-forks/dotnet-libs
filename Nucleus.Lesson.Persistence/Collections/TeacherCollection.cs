using Eliassen.System.Text.Json;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Nucleus.Lesson.Persistence.Collections
{
    public class TeacherCollection
    {
        [BsonElement("userId")]
        public string? UserId { get; set; }
        [BsonElement("fullName")]
        public string? FullName { get; set; }
        [BsonElement("emailAddress")]
        public string? EmailAddress { get; set; }
    }
}
