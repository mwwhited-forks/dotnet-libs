using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;

namespace Eliassen.MailKit.Services;

public class SmtpClientFactory : ISmtpClientFactory
{
    private readonly IOptions<MailKitSmtpClientOptions> _config;

    public SmtpClientFactory(
        IOptions<MailKitSmtpClientOptions> config)
    {
        _config = config;
    }

    public async Task<SmtpClient> Create()
    {
        var client = new SmtpClient();

        if (_config.Value.Uri != null)
        {
            await client.ConnectAsync(_config.Value.Uri);
        }
        else
        {
            await client.ConnectAsync(_config.Value.Host, _config.Value.Port, _config.Value.SecureSocketOption);
        }

        if (!string.IsNullOrWhiteSpace(_config.Value.UserName) && !string.IsNullOrWhiteSpace(_config.Value.Password))
        {
            await client.AuthenticateAsync(_config.Value.UserName, _config.Value.Password);
        }

        return client;
    }
}