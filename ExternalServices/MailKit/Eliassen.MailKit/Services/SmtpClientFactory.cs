using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;

namespace Eliassen.MailKit.Services;

public class SmtpClientFactory(
    IOptions<MailKitSmtpClientOptions> config) : ISmtpClientFactory
{
    public async Task<SmtpClient> Create()
    {
        var client = new SmtpClient();

        if (config.Value.Uri != null)
        {
            await client.ConnectAsync(config.Value.Uri);
        }
        else
        {
            await client.ConnectAsync(config.Value.Host, config.Value.Port, config.Value.SecureSocketOption);
        }

        if (!string.IsNullOrWhiteSpace(config.Value.UserName) && !string.IsNullOrWhiteSpace(config.Value.Password))
        {
            await client.AuthenticateAsync(config.Value.UserName, config.Value.Password);
        }

        return client;
    }
}