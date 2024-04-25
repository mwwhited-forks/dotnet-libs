using System;

namespace Eliassen.Documents;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class VectorStoreAttribute : Attribute
{
    public string? ContainerName { get; set; }
}
