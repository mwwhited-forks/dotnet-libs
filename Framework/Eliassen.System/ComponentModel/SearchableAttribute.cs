using System;

namespace Eliassen.System.ComponentModel
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
