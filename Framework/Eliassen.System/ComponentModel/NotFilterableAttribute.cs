using System;

namespace Eliassen.System.ComponentModel
{
    /// <summary>
    /// Explicitly exclude fields from filter selection. 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class NotFilterableAttribute : Attribute
    {
        public NotFilterableAttribute(string targetName)
        {
            TargetName = targetName;
        }
        public NotFilterableAttribute() { }

        public string? TargetName { get; }
    }
}
