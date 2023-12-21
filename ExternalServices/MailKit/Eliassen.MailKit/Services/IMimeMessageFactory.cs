using Eliassen.Communications.Models;
using MimeKit;

namespace Eliassen.MailKit.Services;

public interface IMimeMessageFactory
{
    MimeMessage Create(EmailMessageModel message);
}
