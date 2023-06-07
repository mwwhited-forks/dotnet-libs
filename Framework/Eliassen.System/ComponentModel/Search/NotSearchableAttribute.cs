using System;

namespace Eliassen.System.ComponentModel.Search
{
    /// <summary>
    /// explicitly exclude properties from search
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class NotSearchableAttribute : Attribute
    {
        public NotSearchableAttribute(string targetName)
        {
            TargetName = targetName;
        }
        public NotSearchableAttribute() { }

        public string? TargetName { get; }
    }
}
