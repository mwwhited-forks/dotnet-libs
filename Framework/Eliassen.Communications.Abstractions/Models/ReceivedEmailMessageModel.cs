namespace Eliassen.Communications.Models;

/// <summary>
/// This model represents inbound email messages
/// </summary>
public class ReceivedEmailMessageModel: EmailMessageModel
{
    /// <summary>
    /// this is the host reference for the inbound message
    /// </summary>
    public string Server { get; set; } = null!;
    /// <summary>
    /// what inbox path is the message received on
    /// </summary>
    public string? Path { get; set; }
}
