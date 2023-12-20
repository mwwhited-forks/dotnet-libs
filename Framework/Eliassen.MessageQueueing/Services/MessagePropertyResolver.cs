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

    private (IConfigurationSection? config, string simpleTargetName, string simpleMessageName, string? configPath) RootConfiguration(Type channelType, Type messageType)
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

        var selected = configs.FirstOrDefault();

        return (selected, simpleTargetName, simpleMessageName, selected?.Path);
    }

    public virtual (IConfigurationSection? providerKey, string simpleTargetName, string simpleMessageName, string? configPath) ConfigurationSafe(Type channelType, Type messageType)
    {
        var (config, simpleTargetName, simpleMessageName, configPath) = RootConfiguration(channelType, messageType);
        var selected = config?.GetSection("Config") ?? config;
        return (selected, simpleTargetName, simpleMessageName, selected?.Path);
    }
    public virtual IConfigurationSection Configuration(Type channelType, Type messageType)
    {
        var (config, simpleTargetName, simpleMessageName, _) = ConfigurationSafe(channelType, messageType);
        if (config == null)
            throw new ApplicationException($"No configuration found for \"MessageQueue:{simpleTargetName}:{simpleMessageName}\"");
        return config;
    }

    public virtual string MessageId(Type channelType, Type messageType, string? messageId) =>
        string.IsNullOrWhiteSpace(messageId) ? GenerateId(channelType, messageType) : messageId;

    public virtual string GenerateId(Type channelType, Type messageType) =>
        Guid.NewGuid().ToString();

    public virtual (string? providerKey, string simpleTargetName, string simpleMessageName, string? configPath) ProviderSafe(Type channelType, Type messageType)
    {
        var (config, simpleTargetName, simpleMessageName, configPath) = RootConfiguration(channelType, messageType);
        var providerKey = config?["Provider"];
        return (providerKey, simpleTargetName, simpleMessageName, configPath);
    }
    public virtual string Provider(Type channelType, Type messageType)
    {
        var (providerKey, simpleTargetName, simpleMessageName, _) = ProviderSafe(channelType, messageType);
        if (providerKey == null)
            throw new ApplicationException($"No provider found for \"MessageQueue:{simpleTargetName}:{simpleMessageName}:Provider\"");
        return providerKey;
    }
}
