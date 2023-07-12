using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Nucleus.Core.Persistence.Collections;

public class PermissionBaseCollection
{
    [BsonElement("name")]
    public string? Name { get; set; }

    [BsonElement("code")]
    public string? Code { get; set; }
}
