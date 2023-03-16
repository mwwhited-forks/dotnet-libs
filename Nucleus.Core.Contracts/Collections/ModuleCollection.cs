using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Nucleus.Core.Contracts.Collections
{
    public class ModuleCollection: PermissionBaseCollection
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? ModuleId { get; set; }

        [BsonElement("roles")]
        public List<RoleCollection>? Roles { get; set; }
    }
}
