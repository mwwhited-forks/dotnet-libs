using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Nucleus.Core.Contracts.Collections
{
    public class PermissionBaseCollection
    {
        [BsonElement("name")]
        public string? Name { get; set; }

        [BsonElement("code")]
        public string? Code { get; set; }
    }
}
