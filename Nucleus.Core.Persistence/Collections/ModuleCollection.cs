using Eliassen.System.Text.Json;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Nucleus.Core.Persistence.Collections;

[CollectionName("modules")]
public class ModuleCollection : PermissionBaseCollection
{
    [Key]
    public string? ModuleId { get; set; }

    public List<RoleCollection>? Roles { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
}
