using System;

namespace Eliassen.System.ComponentModel.Search
{
    /// <summary>
    /// explicitly exclude properties from search
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class NotSearchableAttribute : Attribute
    {
        /// <inheritdoc />
        public NotSearchableAttribute(string targetName)
        {
            TargetName = targetName;
        }
        /// <inheritdoc />
        public NotSearchableAttribute() { }

        /// <summary>
        /// Target name required only if this is used on the class
        /// </summary>
        public string? TargetName { get; }
    }
}
