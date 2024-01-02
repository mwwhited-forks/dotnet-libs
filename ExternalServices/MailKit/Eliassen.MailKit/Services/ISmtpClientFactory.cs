using MailKit.Net.Smtp;

namespace Eliassen.MailKit.Services;

/// <summary>
/// Represents a factory for creating instances of <see cref="SmtpClient"/>.
/// </summary>
public interface ISmtpClientFactory
{
    /// <summary>
    /// Creates a new instance of <see cref="SmtpClient"/>.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation and contains the created <see cref="SmtpClient"/>.</returns>
    Task<SmtpClient> Create();
}
