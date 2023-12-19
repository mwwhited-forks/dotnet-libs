using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Reflection;

namespace Eliassen.MessageQueueing.Services;

public class MessagePropertyResolver : IMessagePropertyResolver
{
    private const string ConfigRootKey = "MessageQueue";
    private const string Default = nameof(Default);

    private readonly IConfiguration _configuration;

    public MessagePropertyResolver(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    private (string target, string message) GetSimpleNames(Type channelType, Type messageType) =>
        (
        channelType == typeof(object) ? Default :
            channelType.GetCustomAttribute<MessageQueueAttribute>()?.SimpleName ?? channelType.Name,
        messageType.GetCustomAttribute<MessageQueueAttribute>()?.SimpleName ?? messageType.Name
        );

    private IConfigurationSection RootConfiguration(Type channelType, Type messageType)
    {
        var (simpleTargetName, simpleMessageName) = GetSimpleNames(channelType, messageType);

        var keys = new[]
        {
            $"{ConfigRootKey}:{simpleTargetName}:{simpleMessageName}",
            $"{ConfigRootKey}:{simpleMessageName}",
            $"{ConfigRootKey}:{simpleTargetName}",
            $"{ConfigRootKey}:{Default}",
        };

        var configs = from key in keys
                      let config = _configuration.GetSection(key)
                      where config != null
                      where config.GetChildren().Any()
                      select config;

        return configs.FirstOrDefault() ??
            throw new ApplicationException($"No configuration found for \"MessageQueue:{simpleTargetName}:{simpleMessageName}\"");
    }

    public virtual IConfigurationSection Configuration(Type channelType, Type messageType)
    {
        var config = RootConfiguration(channelType, messageType);
        return config.GetSection("Config") ?? config;
    }

    public virtual string MessageId(Type channelType, Type messageType, string? messageId) =>
        string.IsNullOrWhiteSpace(messageId) ? GenerateId(channelType, messageType) : messageId;

    public virtual string GenerateId(Type channelType, Type messageType) =>
        Guid.NewGuid().ToString();

    public virtual string Provider(Type channelType, Type messageType)
    {
        var config = RootConfiguration(channelType, messageType);
        var providerKey = config["Provider"]
            ?? throw new ArgumentNullException($"Provider for \"{config.Path}:Provider\" is not configured");

        return providerKey;
    }
}
