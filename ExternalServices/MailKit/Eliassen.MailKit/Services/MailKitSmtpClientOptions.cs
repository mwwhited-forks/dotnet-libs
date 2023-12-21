using MailKit.Security;

namespace Eliassen.MailKit.Services;

public class MailKitSmtpClientOptions
{
    public string Host { get; set; }
    public int Port { get; set; }
    public SecureSocketOptions SecureSocketOption { get; set; }
    public Uri? Uri { get; set; }
    public string? Password { get; set; }
    public string? UserName { get; set; }

    public string? DefaultFromEmailAddress { get; set; }

}
