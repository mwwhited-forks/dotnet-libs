<<<<<<< HEAD
﻿using Eliassen.System.Text.Json;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
=======
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
>>>>>>> 42f4ded (fixup id conventions for bson)

namespace Nucleus.Core.Persistence.Collections
{
<<<<<<< HEAD
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [JsonPropertyName("_id")]
    [JsonConverter(typeof(BsonIdConverter))]
    public string? UserId { get; set; }
    public string? UserName { get; set; }
    public string? EmailAddress { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public bool Active { get; set; }
    public List<UserModuleCollection>? UserModules { get; set; }
    [JsonConverter(typeof(BsonDateConverter))]
    public DateTimeOffset? CreatedOn { get; set; }
=======
    public class UserCollection
    {
        public string? UserId { get; set; }
        public string? UserName { get; set; }
        public string? EmailAddress { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool Active { get; set; }
        public List<UserModuleCollection>? UserModules { get; set; }
        public DateTimeOffset? CreatedOn { get; set; }
    }
>>>>>>> 42f4ded (fixup id conventions for bson)
}