using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Nucleus.Core.Persistence.Collections;

public class RoleCollection : PermissionBaseCollection
{
    public List<PermissionBaseCollection>? Rights { get; set; }
}
