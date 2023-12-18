using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Eliassen.System.Text.Json;
using System.ComponentModel;

namespace Eliassen.MessageQueueing.Services;

public class MessageSenderContext : IMessageSenderContext
{
    public string MessageId { get; set; } = null!;

    public Dictionary<string, object?> Headers { get; } = new();

    public IConfigurationSection Config { get; set; } = null!;
}
