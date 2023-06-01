using System;

namespace Eliassen.System.ComponentModel.Search
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class NotSortableAttribute : Attribute
    {
        public NotSortableAttribute(string targetName)
        {
            TargetName = targetName;
        }
        public NotSortableAttribute() { }

        public string? TargetName { get; }
    }
}
