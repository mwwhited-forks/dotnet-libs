using System;

namespace Eliassen.System.Configuration
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class CommandParameterAttribute : Attribute
    {
        public string? Short { get; set; }
        public string? Value { get; set; }

        public override object TypeId => this;
    }
}