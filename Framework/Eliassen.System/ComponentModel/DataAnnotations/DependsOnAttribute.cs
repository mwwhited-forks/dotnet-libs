using System;

namespace Eliassen.System.ComponentModel.DataAnnotations
{
    /// <summary>
    /// You can use this attribute to configure an entity dependency versus using a navigation property
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class DependsOnAttribute : Attribute
    {
        public DependsOnAttribute(params Type[] types)
        {
            Types = types;
        }

        public Type[] Types { get; }
    }
}
