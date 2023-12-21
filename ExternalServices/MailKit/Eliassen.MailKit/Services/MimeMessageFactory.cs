using Eliassen.Communications.Models;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Eliassen.MailKit.Services;

public class MimeMessageFactory : IMimeMessageFactory
{
    private readonly IOptions<MailKitSmtpClientOptions> _config;

    public MimeMessageFactory(
        IOptions<MailKitSmtpClientOptions> config)
    {
        _config = config;
    }


    public MimeMessage Create(EmailMessageModel message)
    {
        var email = new MimeMessage
        {
            From =
            {
                InternetAddress.Parse(message.FromAddress ?? _config.Value.DefaultFromEmailAddress),
            }
        };

        if (!string.IsNullOrWhiteSpace(message.ReferenceId))
        {
            email.Headers.Add($"X-{nameof(message.ReferenceId)}", message.ReferenceId);

        }
        foreach (var header in message.Headers.Where(kvp => kvp.Value != null))
        {
            email.Headers.Add(header.Key, header.Value);
        }

        email.To.AddRange(message.ToAddresses.Select(m => InternetAddress.Parse(m)));
        email.Cc.AddRange(message.CcAddresses.Select(m => InternetAddress.Parse(m)));
        email.Bcc.AddRange(message.BccAddresses.Select(m => InternetAddress.Parse(m)));

        email.Subject = message.Subject;

        var bodyBuilder = new BodyBuilder();
        if (string.IsNullOrWhiteSpace(message.TextContent) && string.IsNullOrWhiteSpace(message.HtmlContent))
        {
            throw new NotSupportedException("You must provide Text or Html Body");
        }
        if (!string.IsNullOrWhiteSpace(message.TextContent))
        {
            bodyBuilder.TextBody = message.TextContent;
        }
        if (!string.IsNullOrWhiteSpace(message.HtmlContent))
        {
            bodyBuilder.HtmlBody = message.HtmlContent;
        }
        email.Body = bodyBuilder.ToMessageBody();

        //TODO: add attachment support

        return email;
    }
}
