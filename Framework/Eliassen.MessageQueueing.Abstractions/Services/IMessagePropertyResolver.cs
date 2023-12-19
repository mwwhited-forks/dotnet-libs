using Microsoft.Extensions.Configuration;

namespace Eliassen.MessageQueueing.Services;

public interface IMessagePropertyResolver
{
    string Provider(Type channelType, Type messageType);
    string MessageId(Type channelType, Type messageType, string? messageId);
    string GenerateId(Type channelType, Type messageType);

    IConfigurationSection Configuration(Type channelType, Type messageType);
}
