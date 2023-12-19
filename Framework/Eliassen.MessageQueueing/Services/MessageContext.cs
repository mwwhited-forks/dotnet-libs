using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Eliassen.MessageQueueing.Services;

public class MessageContext : IMessageContext
{
    public string? OriginMessageId
    {
        get => this[$"X-{nameof(OriginMessageId)}"] as string;
        internal set => this[$"X-{nameof(OriginMessageId)}"] = value;
    }
    public string? CorrelationId
    {
        get => this[$"X-{nameof(CorrelationId)}"] as string;
        set => this[$"X-{nameof(CorrelationId)}"] = value;
    }
    public string? RequestId
    {
        get => this[$"X-{nameof(RequestId)}"] as string;
        internal set => this[$"X-{nameof(RequestId)}"] = value;
    }
    public string? SentId
    {
        get => this[$"X-{nameof(SentId)}"] as string;
        set => this[$"X-{nameof(SentId)}"] = value;
    }

    public string? ChannelType
    {
        get => this[$"X-{nameof(ChannelType)}"] as string;
        internal set => this[$"X-{nameof(ChannelType)}"] = value;
    }
    public string? MessageType
    {
        get => this[$"X-{nameof(MessageType)}"] as string;
        internal set => this[$"X-{nameof(MessageType)}"] = value;
    }

    public DateTimeOffset? SentAt
    {
        get => this[$"X-{nameof(SentAt)}"] as DateTimeOffset?;
        internal set => this[$"X-{nameof(SentAt)}"] = value;
    }
    public string? SentBy
    {
        get => this[$"X-{nameof(SentBy)}"] as string;
        internal set => this[$"X-{nameof(SentBy)}"] = value;
    }
    public string? SentFrom
    {
        get => this[$"X-{nameof(SentFrom)}"] as string;
        internal set => this[$"X-{nameof(SentFrom)}"] = value;
    }

    [JsonIgnore]
    public object? this[string key]
    {
        get => Headers.TryGetValue(key, out var value) ? value : null;
        set
        {
            if (!Headers.TryAdd(key, value))
                Headers[key] = value;
        }
    }

    public Dictionary<string, object?> Headers { get; } = new();

    public IConfigurationSection Config { get; internal set; } = null!;
}
