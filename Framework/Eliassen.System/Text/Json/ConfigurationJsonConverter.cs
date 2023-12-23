using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Eliassen.System.Text.Json;

/// <summary>
/// JsonConverter for serializing and deserializing IConfiguration instances.
/// </summary>
/// <typeparam name="IConfig">The type of IConfiguration.</typeparam>
public class ConfigurationJsonConverter<IConfig> : JsonConverter<IConfig>
    where IConfig : IConfiguration
{
    /// <inheritdoc/>
    public override IConfig? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var dict = JsonSerializer.Deserialize<Dictionary<string, string?>>(ref reader, options);

        var builder = new ConfigurationBuilder();
        builder.AddInMemoryCollection(dict);

        var config = builder.Build();

        if (typeToConvert.IsInstanceOfType(config))
            return (IConfig)config;
        else if (typeToConvert == typeof(IConfigurationSection))
            return (IConfig?)(config.GetChildren().FirstOrDefault());

        throw new NotSupportedException($"could not convert {config.GetType()} to {typeToConvert}");
    }

    /// <inheritdoc/>
    public override void Write(Utf8JsonWriter writer, IConfig value, JsonSerializerOptions options)
    {
        var dict = value.AsEnumerable()
            .Where(l => !string.IsNullOrWhiteSpace(l.Value))
            .ToDictionary(k => k.Key, k => k.Value);
        JsonSerializer.Serialize(writer, dict, options);
    }
}