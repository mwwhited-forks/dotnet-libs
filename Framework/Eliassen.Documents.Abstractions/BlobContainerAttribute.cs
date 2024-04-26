using System;

namespace Eliassen.Documents;

/// <summary>
/// Configuration attribute for Blob Containers
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class BlobContainerAttribute : Attribute
{
    /// <summary>
    /// Blob Container Name
    /// </summary>
    public string? ContainerName { get; set; }
}
