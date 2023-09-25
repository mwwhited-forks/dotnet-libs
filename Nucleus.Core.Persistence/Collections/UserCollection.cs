
using Eliassen.System.Text.Json;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Nucleus.Core.Persistence.Collections;

[CollectionName("users")]
public class UserCollection
{
    [Key]
    public string? UserId { get; set; }
    public string? UserName { get; set; }
    public string? EmailAddress { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public bool Active { get; set; }
    public List<UserModuleCollection>? UserModules { get; set; }
    public DateTimeOffset? CreatedOn { get; set; }
}