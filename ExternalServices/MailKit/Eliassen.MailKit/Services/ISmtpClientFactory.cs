using MailKit.Net.Smtp;

namespace Eliassen.MailKit.Services;

public interface ISmtpClientFactory
{
    Task<SmtpClient> Create();
}
