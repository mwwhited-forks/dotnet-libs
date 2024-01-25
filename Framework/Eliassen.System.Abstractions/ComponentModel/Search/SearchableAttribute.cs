namespace Eliassen.System.ComponentModel.Search;

/// <summary>
/// include field to be searchable for "SearchTerm"
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
public class SearchableAttribute : Attribute
{

    public SearchableAttribute(string targetName) => TargetName = targetName;

    public SearchableAttribute() { }

    /// <summary>
    /// Target name required only if this is used on the class
    /// </summary>
    public string? TargetName { get; }
}
