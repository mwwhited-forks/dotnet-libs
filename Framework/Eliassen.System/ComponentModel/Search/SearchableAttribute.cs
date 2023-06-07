using System;

namespace Eliassen.System.ComponentModel.Search
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class SearchableAttribute : Attribute
    {
        public SearchableAttribute(string targetName)
        {
            TargetName = targetName;
        }
        public SearchableAttribute() { }

        public string? TargetName { get; }
    }
}
