using Eliassen.System.Text.Json;
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
    [JsonConverter(typeof(BsonIdConverter))]
    public string? ModuleId { get; set; }

    [BsonElement("roles")]
    public List<RoleCollection>? Roles { get; set; }

    [BsonElement("createdOn")]
    [JsonConverter(typeof(BsonDateConverter))]
    public DateTimeOffset CreatedOn { get; set; }
}
