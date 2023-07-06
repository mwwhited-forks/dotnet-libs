using Eliassen.System.Linq.Search;

namespace Eliassen.System.ComponentModel.Search;

/// <summary>
/// part of default sort for entity
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
public class DefaultSortAttribute : Attribute
{
    /// <inheritdoc/>
    public DefaultSortAttribute(
        string? targetName = default,
        int priority = default,
        OrderDirections order = OrderDirections.Ascending
        )
    {
        TargetName = targetName;
        Priority = priority;
        Order = order;
    }
    /// <inheritdoc/>
    public DefaultSortAttribute() { }

    /// <summary>
    /// property name to use for mapping
    /// </summary>
    public string? TargetName { get; }

    /// <summary>
    /// sort column position priority 
    /// </summary>
    public int Priority { get; }

    /// <summary>
    /// direction to order this mapped column
    /// </summary>
    public OrderDirections Order { get; }
}
