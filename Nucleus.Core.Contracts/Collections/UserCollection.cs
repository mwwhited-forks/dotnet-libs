using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleus.Core.Contracts.Collections
{
    [BsonIgnoreExtraElements]
    public class UserCollection
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? UserId { get; set; }

        [BsonElement("userName")]
        public string? UserName { get; set; }

        [BsonElement("emailAddress")]
        public string? EmailAddress { get; set; }

        [BsonElement("firstName")]
        public string? FirstName { get; set; }

        [BsonElement("lastName")]
        public string? LastName { get; set; }

        [BsonElement("active")]
        public bool Active { get; set; }

        [BsonElement("userModules")]
        public List<UserModuleCollection>? UserModules { get; set; }

        [BsonElement("createdOn")]
        public DateTimeOffset? CreatedOn { get; set; }
    }
}
