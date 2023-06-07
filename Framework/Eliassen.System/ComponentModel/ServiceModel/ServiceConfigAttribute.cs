using System;

namespace Eliassen.System.ComponentModel.ServiceModel
{
    /// <summary>
    /// This may be used with services provided by ISelectedService to enable configuration
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public sealed class ServiceConfigAttribute : Attribute
    {
        /// <summary>
        /// this option will allows services to be selected in an explicit order
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// optional value that may be used for matching configured value
        /// </summary>
        public string? MatchKey { get; set; }
    }
}
