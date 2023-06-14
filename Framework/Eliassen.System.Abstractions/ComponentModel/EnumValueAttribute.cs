using System;

namespace Eliassen.System.ComponentModel
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public sealed class EnumValueAttribute : Attribute
    {
        public EnumValueAttribute(string name)
        {
            Name = name;
        }

        /// <summary>
        /// value to output in place of Enum.ToString() with Json Serializer
        /// </summary>
        public string Name { get; private set; }
    }
}
