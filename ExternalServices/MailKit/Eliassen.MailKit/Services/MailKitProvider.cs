using Eliassen.Communications.Models;
using Eliassen.Communications.Services;
using Microsoft.Extensions.Logging;

namespace Eliassen.MailKit.Services;

public class MailKitProvider : IMessageSender<EmailMessageModel>
{
    private readonly IMimeMessageFactory _email;
    private readonly ISmtpClientFactory _smtp;
    private readonly ILogger _log;

    public MailKitProvider(
        IMimeMessageFactory email,
        ISmtpClientFactory smtp,
        ILogger<MailKitProvider> log
        )
    {
        _email = email;
        _smtp = smtp;
        _log = log;
    }

    public async Task<string> SendAsync(EmailMessageModel message)
    {
        var email = _email.Create(message);
        using var client = await _smtp.Create();

        var reference = await client.SendAsync(email);
        await client.DisconnectAsync(true);

        _log.LogInformation($@"Sent email ""{{{nameof(message.Subject)}}}"" to ""{{{nameof(message.ToAddresses)}}}"" [{{{nameof(reference)}}}]", message.Subject, message.ToAddresses, reference);

        return reference;
    }
}
