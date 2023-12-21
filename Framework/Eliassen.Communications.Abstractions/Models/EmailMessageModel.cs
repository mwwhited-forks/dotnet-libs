namespace Eliassen.Communications.Models;

public class EmailMessageModel
{
    public string? ReferenceId { get; set; }

    public string? FromAddress { get; set; }

    public List<string> ToAddresses { get; set; } = new();
    public List<string> CcAddresses { get; set; } = new();
    public List<string> BccAddresses { get; set; } = new();

    public string? Subject { get; set; }
    public string? TextContent { get; set; }
    public string? HtmlContent { get; set; }

    public Dictionary<string, string> Headers { get; set; } = new();

    public List<AttachmentReferenceModel> Attachments { get; set; } = new();
}
