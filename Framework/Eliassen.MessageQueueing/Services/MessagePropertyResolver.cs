using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Reflection;

namespace Eliassen.MessageQueueing.Services;
/// <summary>
/// Utility class for resolving properties related to message queue handling.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="MessagePropertyResolver"/> class with the specified configuration.
/// </remarks>
/// <param name="configuration">The configuration used for resolving message queue properties.</param>
public class MessagePropertyResolver(IConfiguration configuration) : IMessagePropertyResolver
{
    private const string ConfigRootKey = "MessageQueue";
    private const string Default = nameof(Default);

    private static (string target, string message) GetSimpleNames(Type channelType, Type messageType) =>
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
                      let config = configuration.GetSection(key)
                      where config != null
                      where config.GetChildren().Any()
                      select config;

        var selected = configs.FirstOrDefault();

        return (selected, simpleTargetName, simpleMessageName, selected?.Path);
    }

    /// <inheritdoc/>
    public (IConfigurationSection? configurationSection, string simpleTargetName, string simpleMessageName, string? configPath) ConfigurationSafe(Type channelType, Type messageType)
    {
        var (config, simpleTargetName, simpleMessageName, configPath) = RootConfiguration(channelType, messageType);
        var selected = config?.GetSection("Config") ?? config;
        return (selected, simpleTargetName, simpleMessageName, selected?.Path);
    }

    /// <inheritdoc/>
    public virtual IConfigurationSection Configuration(Type channelType, Type messageType)
    {
        var (config, simpleTargetName, simpleMessageName, _) = ConfigurationSafe(channelType, messageType);
        if (config == null)
            throw new ApplicationException($"No configuration found for \"MessageQueue:{simpleTargetName}:{simpleMessageName}\"");
        return config;
    }

    /// <inheritdoc/>
    public virtual string MessageId(Type channelType, Type messageType, string? messageId) =>
        string.IsNullOrWhiteSpace(messageId) ? GenerateId(channelType, messageType) : messageId;

    /// <inheritdoc/>
    public virtual string GenerateId(Type channelType, Type messageType) =>
        Guid.NewGuid().ToString();

    /// <inheritdoc/>
    public virtual (string? providerKey, string simpleTargetName, string simpleMessageName, string? configPath) ProviderSafe(Type channelType, Type messageType)
    {
        var (config, simpleTargetName, simpleMessageName, configPath) = RootConfiguration(channelType, messageType);
        var providerKey = config?["Provider"];
        return (providerKey, simpleTargetName, simpleMessageName, configPath);
    }

    /// <inheritdoc/>
    public virtual string Provider(Type channelType, Type messageType)
    {
        var (providerKey, simpleTargetName, simpleMessageName, _) = ProviderSafe(channelType, messageType);
        if (providerKey == null)
            throw new ApplicationException($"No provider found for \"MessageQueue:{simpleTargetName}:{simpleMessageName}:Provider\"");
        return providerKey;
    }
}