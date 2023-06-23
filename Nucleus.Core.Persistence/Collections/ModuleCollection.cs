using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Nucleus.Core.Persistence.Collections;

[BsonIgnoreExtraElements]
public class ModuleCollection : PermissionBaseCollection
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [JsonPropertyName("_id")]
    public string? ModuleId { get; set; }

    [BsonElement("roles")]
    public List<RoleCollection>? Roles { get; set; }

    [BsonElement("createdOn")]
    public DateTimeOffset CreatedOn { get; set; }
}
