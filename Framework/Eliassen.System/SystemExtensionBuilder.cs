using Eliassen.System.Security.Cryptography;
using Eliassen.System.Text;
using Eliassen.System.Text.Templating;

namespace Eliassen.System;

/// <summary>
/// Represents a builder for configuring system extensions.
/// </summary>
public record SystemExtensionBuilder
{
    /// <summary>
    /// Gets or sets the configuration section name for file templating options.
    /// </summary>
    /// <value>
    /// The configuration section name for file templating options. Default is "FileTemplatingOptions".
    /// </value>
    public string FileTemplatingConfigurationSection { get; init; } = nameof(FileTemplatingOptions);

    /// <summary>
    /// Gets or sets the default hash type to be used.
    /// </summary>
    /// <value>
    /// The default hash type. The default value is <see cref="HashTypes.Md5"/>.
    /// </value>
    public HashTypes DefaultHashType { get; init; } = HashTypes.Md5;

    /// <summary>
    /// Gets or sets the default serializer type to be used.
    /// </summary>
    /// <value>
    /// The default serializer type. The default value is <see cref="SerializerTypes.Json"/>.
    /// </value>
    public SerializerTypes DefaultSerializerType { get; init; } = SerializerTypes.Json;
}
