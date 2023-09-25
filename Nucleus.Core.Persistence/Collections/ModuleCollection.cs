<<<<<<< HEAD
﻿using Eliassen.System.Text.Json;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
=======
﻿using System;
>>>>>>> 42f4ded (fixup id conventions for bson)
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Nucleus.Core.Persistence.Collections
{
<<<<<<< HEAD
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [JsonPropertyName("_id")]
    [JsonConverter(typeof(BsonIdConverter))]
    public string? ModuleId { get; set; }

    public List<RoleCollection>? Roles { get; set; }

    [JsonConverter(typeof(BsonDateConverter))]
    public DateTimeOffset CreatedOn { get; set; }
}
=======
    public class ModuleCollection : PermissionBaseCollection
    {
        public string? ModuleId { get; set; }

        public List<RoleCollection>? Roles { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
    }
}
>>>>>>> 42f4ded (fixup id conventions for bson)
