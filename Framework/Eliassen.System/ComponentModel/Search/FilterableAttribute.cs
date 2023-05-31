using System;

namespace Eliassen.System.ComponentModel.Search
{
    /// <summary>
    /// Allow tagging entity classes to enumerate filterable fields/properties.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class FilterableAttribute : Attribute
    {
        public FilterableAttribute(string targetName)
        {
            TargetName = targetName;
        }
        public FilterableAttribute() { }

        public string? TargetName { get; }
    }
}
