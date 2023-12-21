namespace Eliassen.Communications.Models;

public class SmsMessageModel
{
    public string? From { get; set; }
    public string? To { get; set; }
     
    public Guid RequestId { get; set; }
     
    public string? Body { get; set; }

    public IDictionary<string, object> Headers { get; set; }
}
