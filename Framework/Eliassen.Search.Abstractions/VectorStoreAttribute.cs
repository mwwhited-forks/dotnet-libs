using System;

namespace Eliassen.Search;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class VectorStoreAttribute : Attribute
{
    public string? ContainerName { get; set; }
}
