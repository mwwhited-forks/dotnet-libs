namespace Eliassen.System.Configuration;

/// <summary>
/// Specifies the configuration section associated with a class.
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class ConfigurationSectionAttribute : Attribute
{
    /// <summary>
    /// Gets the configuration section name.
    /// </summary>
    public string ConfigurationSection { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ConfigurationSectionAttribute"/> class.
    /// </summary>
    /// <param name="configurationSection">The configuration section name.</param>
    public ConfigurationSectionAttribute(
        string configurationSection
        )
    {
        ConfigurationSection = configurationSection;
    }

    /// <summary>
    /// Gets a unique identifier for this attribute.
    /// </summary>
    public override object TypeId => this;
}