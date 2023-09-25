<<<<<<< HEAD
﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Nucleus.Core.Persistence.Collections;

public class PermissionBaseCollection
=======
﻿namespace Nucleus.Core.Persistence.Collections
>>>>>>> 42f4ded (fixup id conventions for bson)
{
    public class PermissionBaseCollection
    {
        public string? Name { get; set; }
        public string? Code { get; set; }
    }
}