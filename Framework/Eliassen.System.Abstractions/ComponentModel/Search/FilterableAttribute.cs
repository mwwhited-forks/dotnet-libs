namespace Eliassen.System.ComponentModel.Search;

/// <summary>
/// Allow tagging entity classes to enumerate filterable fields/properties.
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
public class FilterableAttribute : Attribute
{
    /// <inheritdoc/>
    public FilterableAttribute(string targetName)
    {
        TargetName = targetName;
    }
    /// <inheritdoc/>
    public FilterableAttribute() { }

    /// <summary>
    /// column mapping override
    /// </summary>
    public string? TargetName { get; }
}
