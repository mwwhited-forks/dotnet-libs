using Eliassen.System.Linq.Search;
using System;

namespace Eliassen.System.ComponentModel.Search
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class DefaultSortAttribute : Attribute
    {
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
        public DefaultSortAttribute() { }

        public string? TargetName { get; }
        public int Priority { get; }
        public OrderDirections Order { get; }
    }
}
