namespace Eliassen.Communications.Models;

public class ReceivedEmailMessageModel: EmailMessageModel
{
    public string Server { get; set; } = null!;
    public string? Path { get; set; }
}
