using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Eliassen.MessageQueueing.Services;

public interface IMessageContextFactory
{
    IMessageContext Create(
        Type channelType,
        Type messageType,
        string? originMessageId,
        string correlationId,
        string requestId,
        IConfigurationSection configuration,
        /*[CallerMemberName]*/ MethodBase? caller     /* = default */,
        /*[CallerLineNumber]*/ int callerLine     /* = default */,
        /*[CallerFilePath]  */ string? callerFile /* = default */
        );
    IMessageContext Create(Type channelType, IQueueMessage message, IConfigurationSection configuration);
}
