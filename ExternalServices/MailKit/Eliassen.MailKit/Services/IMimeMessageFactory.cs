using Eliassen.Communications.Models;
using MimeKit;

namespace Eliassen.MailKit.Services;

/// <summary>
/// Represents a factory for creating <see cref="MimeMessage"/> instances from <see cref="EmailMessageModel"/>.
/// </summary>
public interface IMimeMessageFactory
{
    /// <summary>
    /// Creates a <see cref="MimeMessage"/> from the specified <see cref="EmailMessageModel"/>.
    /// </summary>
    /// <param name="message">The email message model.</param>
    /// <returns>A <see cref="MimeMessage"/> instance.</returns>
    MimeMessage Create(EmailMessageModel message);
}
