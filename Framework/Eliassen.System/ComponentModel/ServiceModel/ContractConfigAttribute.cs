using System;

namespace Eliassen.System.ComponentModel.ServiceModel
{
    /// <summary>
    /// For use with ISelectedService to setup contract interface for configuration
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface, AllowMultiple = false, Inherited = false)]
    public sealed class ContractConfigAttribute : Attribute
    {
        /// <summary>
        /// Service is required.  If false then null might be returned.
        /// </summary>
        public bool IsRequired { get; set; }

        /// <summary>
        /// If multiple values are found a config setting must be provided.
        /// If false the ServicePriority will take precedence.  If true and
        /// config value is not set then an exception will be thrown
        /// </summary>
        public bool RequireConfiguration { get; set; }

        /// <summary>
        /// configuration key override.  If not provided the configuration key will 
        /// be targeted as WebApp:ConfiguredServices:{typeof(T).FullName}
        /// </summary>
        public string? ConfigKey { get; set; }

        /// <summary>
        /// Allow default selection if not matched.
        /// </summary>
        public bool AllowDefault { get; set; } = true;
    }
}
