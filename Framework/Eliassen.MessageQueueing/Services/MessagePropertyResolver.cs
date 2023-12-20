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

    private (IConfigurationSection? config, string simpleTargetName, string simpleMessageName) RootConfiguration(Type channelType, Type messageType)
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

        return (configs.FirstOrDefault(), simpleTargetName, simpleMessageName);
    }

    public virtual (IConfigurationSection? providerKey, string simpleTargetName, string simpleMessageName) ConfigurationSafe(Type channelType, Type messageType)
    {
        var (config, simpleTargetName, simpleMessageName) = RootConfiguration(channelType, messageType);
        return (config?.GetSection("Config") ?? config, simpleTargetName, simpleMessageName);
    }
    public virtual IConfigurationSection Configuration(Type channelType, Type messageType)
    {
        var (config, simpleTargetName, simpleMessageName) = ConfigurationSafe(channelType, messageType);
        if (config == null)
            throw new ApplicationException($"No configuration found for \"MessageQueue:{simpleTargetName}:{simpleMessageName}\"");
        return config;
    }

    public virtual string MessageId(Type channelType, Type messageType, string? messageId) =>
        string.IsNullOrWhiteSpace(messageId) ? GenerateId(channelType, messageType) : messageId;

    public virtual string GenerateId(Type channelType, Type messageType) =>
        Guid.NewGuid().ToString();

    public virtual (string? providerKey, string simpleTargetName, string simpleMessageName) ProviderSafe(Type channelType, Type messageType)
    {
        var (config, simpleTargetName, simpleMessageName) = RootConfiguration(channelType, messageType);
        var providerKey = config?["Provider"];
        return (providerKey, simpleTargetName, simpleMessageName);
    }
    public virtual string Provider(Type channelType, Type messageType)
    {
        var (providerKey, simpleTargetName, simpleMessageName) = ProviderSafe(channelType, messageType);
        if (providerKey == null)
            throw new ApplicationException($"No provider found for \"MessageQueue:{simpleTargetName}:{simpleMessageName}:Provider\"");
        return providerKey;
    }
}
