using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Nucleus.Core.Persistence.Collections;

public class PermissionBaseCollection
{
    public string? Name { get; set; }
    public string? Code { get; set; }
}
