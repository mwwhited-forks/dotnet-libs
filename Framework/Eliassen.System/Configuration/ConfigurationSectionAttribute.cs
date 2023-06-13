using System;

namespace Eliassen.System.Configuration
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ConfigurationSectionAttribute : Attribute
    {
        public string ConfigurationSection { get; }

        public ConfigurationSectionAttribute(
            string configurationSection
            )
        {
            ConfigurationSection = configurationSection;
        }

        public override object TypeId => this;
    }
}