namespace Eliassen.System.Configuration;

/// <summary>
/// Specifies the configuration section associated with a class.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="ConfigurationSectionAttribute"/> class.
/// </remarks>
/// <param name="configurationSection">The configuration section name.</param>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class ConfigurationSectionAttribute(
    string configurationSection
        ) : Attribute
{
    /// <summary>
    /// Gets the configuration section name.
    /// </summary>
    public string ConfigurationSection { get; } = configurationSection;

    /// <summary>
    /// Gets a unique identifier for this attribute.
    /// </summary>
    public override object TypeId => this;
}