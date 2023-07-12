namespace Eliassen.System.ComponentModel;

/// <summary>
/// output enum string as this value when serialized as json
/// </summary>
[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
public sealed class EnumValueAttribute : Attribute
{
    /// <inheritdoc />
    public EnumValueAttribute(string name)
    {
        Name = name;
    }

    /// <summary>
    /// value to output in place of Enum.ToString() with Json Serializer
    /// </summary>
    public string Name { get; init; }
}
