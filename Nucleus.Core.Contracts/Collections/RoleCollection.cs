using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Text;

namespace Nucleus.Core.Contracts.Collections
{
    public class RoleCollection : PermissionBaseCollection
    {
        [BsonElement("rights")]
        public List<PermissionBaseCollection>? Rights { get; set; }
    }
}
