using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Collections.Generic;

namespace Nucleus.Core.Contracts.Collections
{
    public class UserModuleCollection : PermissionBaseCollection
    {
        [BsonElement("roles")]
        public List<RoleCollection>? Roles { get; set; }

    }
}
