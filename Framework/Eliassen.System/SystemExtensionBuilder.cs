using Eliassen.System.Security.Cryptography;
using Eliassen.System.Text;
using Eliassen.System.Text.Templating;

namespace Eliassen.System;

public record SystemExtensionBuilder
{
    public string FileTemplatingConfigurationSection { get; init; } = nameof(FileTemplatingOptions);
    public HashTypes DefaultHashType { get; init; } = HashTypes.Md5;
    public SerializerTypes DefaultSerializerType { get; init; } = SerializerTypes.Json;
}
