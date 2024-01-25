using Microsoft.Extensions.Configuration;

namespace Eliassen.MessageQueueing.Services;
/// <summary>
/// Provides a mechanism for handling queue messages.
/// </summary>
public interface IMessageHandlerProvider
{
    /// <summary>
    /// Handles the specified queue message with the given message identifier.
    /// </summary>
    /// <param name="message">The queue message to handle.</param>
    /// <param name="messageId">The identifier associated with the message.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task HandleAsync(IQueueMessage message, string messageId);

    /// <summary>
    /// Gets the configuration section associated with the message handler provider.
    /// </summary>
    IConfigurationSection Config { get; }

    /// <summary>
    /// Sets the collection of message queue handlers for the provider.
    /// </summary>
    /// <param name="handlers">The collection of message queue handlers.</param>
    /// <returns>The updated message handler provider.</returns>
    internal IMessageHandlerProvider SetHandlers(IEnumerable<IMessageQueueHandler> handlers);

    /// <summary>
    /// Sets the type of the message channel for the provider.
    /// </summary>
    /// <param name="channelType">The type of the message channel.</param>
    /// <returns>The updated message handler provider.</returns>
    internal IMessageHandlerProvider SetChannelType(Type channelType);

    /// <summary>
    /// Sets the configuration section for the provider.
    /// </summary>
    /// <param name="config">The configuration section.</param>
    /// <returns>The updated message handler provider.</returns>
    internal IMessageHandlerProvider SetConfig(IConfigurationSection config);
}
