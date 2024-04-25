using System;

namespace Eliassen.Documents;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class BlobContainerAttribute : Attribute
{
    public string? ContainerName { get; set; }
}
