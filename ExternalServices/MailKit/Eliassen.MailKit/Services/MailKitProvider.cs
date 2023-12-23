using Eliassen.Communications.Models;
using Eliassen.Communications.Services;
using Microsoft.Extensions.Logging;

namespace Eliassen.MailKit.Services;

public class MailKitProvider(
    IMimeMessageFactory email,
    ISmtpClientFactory smtp,
    ILogger<MailKitProvider> log
        ) : ICommunicationSender<EmailMessageModel>
{
    private readonly IMimeMessageFactory _email = email;
    private readonly ILogger _log = log;

    public async Task<string> SendAsync(EmailMessageModel message)
    {
        var email = _email.Create(message);
        using var client = await smtp.Create();

        var reference = await client.SendAsync(email);
        await client.DisconnectAsync(true);

        _log.LogInformation($@"Sent email ""{{{nameof(message.Subject)}}}"" to ""{{{nameof(message.ToAddresses)}}}"" [{{{nameof(reference)}}}]", message.Subject, message.ToAddresses, reference);

        return reference;
    }
}
