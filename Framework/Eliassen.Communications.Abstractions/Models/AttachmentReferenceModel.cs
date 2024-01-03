namespace Eliassen.Communications.Models;

/// <summary>
/// Represents a model for referencing attachments.
/// </summary>
public class AttachmentReferenceModel
{
    /// <summary>
    /// Gets the name of the container where the attachment is stored.
    /// </summary>
    public string ContainerName { get; init; } = null!;

    /// <summary>
    /// Gets the key or identifier of the document associated with the attachment.
    /// </summary>
    public string DocumentKey { get; init; } = null!;
}
