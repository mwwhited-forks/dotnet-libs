using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Reflection;

namespace Eliassen.MessageQueueing.Services;

public class MessageSenderResolver : IMessageSenderResolver
{
    private readonly IConfiguration _configuration;

    public MessageSenderResolver(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    private (string target, string message) GetSimpleNames(Type targetQueueType, Type messageType) =>
        (
        targetQueueType.GetCustomAttribute<MessageQueueAttribute>()?.SimpleName ?? targetQueueType.Name,
        messageType.GetCustomAttribute<MessageQueueAttribute>()?.SimpleName ?? messageType.Name
        );

    private IConfigurationSection RootConfiguration(Type targetQueueType, Type messageType)
    {
        var (simpleTargetName, simpleMessageName) = GetSimpleNames(targetQueueType, messageType);

        var keys = new[]
        {
            $"MessageQueue:{simpleTargetName}:{simpleMessageName}",
            $"MessageQueue:{simpleMessageName}",
            $"MessageQueue:{simpleTargetName}",
            $"MessageQueue:Default",
        };

        var configs = from key in keys
                      let config = _configuration.GetSection(key)
                      where config != null
                      where config.GetChildren().Any()
                      select config;

        return configs.FirstOrDefault() ??
            throw new ApplicationException($"No configuration found for \"MessageQueue:{simpleTargetName}:{simpleMessageName}\"");
    }

    public virtual IConfigurationSection Configuration(Type targetQueueType, Type messageType)
    {
        var config = RootConfiguration(targetQueueType, messageType);
        return config.GetSection("Config") ?? config;
    }

    public virtual string MessageId(Type targetQueueType, Type messageType, string? messageId) =>
        string.IsNullOrWhiteSpace(messageId) ? Guid.NewGuid().ToString() : messageId;

    public virtual string Provider(Type targetQueueType, Type messageType)
    {
        var config = RootConfiguration(targetQueueType, messageType);
        var providerKey = config["Provider"]
            ?? throw new ArgumentNullException($"Provider for \"{config.Path}:Provider\" is not configured");

        return providerKey;
    }
}
