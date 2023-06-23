using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Eliassen.System.Configuration
{
    /// <summary>
    /// builder pattern for command parameter arguments
    /// </summary>
    public static class CommandLine
    {
        private static StringComparer Comparer = StringComparer.InvariantCultureIgnoreCase;

        /// <summary>
        /// add additional configurable parameters
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public static IDictionary<string, string> AddParameters<T>(this IDictionary<string, string> items) =>
            items.Concat(BuildParameters<T>())
                 .GroupBy(i => i.Key, Comparer)
                 .ToDictionary(i => i.Key, i => i.First().Value, Comparer)
                 ;

        /// <summary>
        /// entry point or defining configurable parameters
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IDictionary<string, string> BuildParameters<T>()
        {
            var type = typeof(T);
            var section = TypeDescriptor.GetAttributes(type).OfType<ConfigurationSectionAttribute>().FirstOrDefault()?.ConfigurationSection ?? type.Name;

            var properties = from property in TypeDescriptor.GetProperties(type).OfType<PropertyDescriptor>()
                             let attribute = property.Attributes.OfType<CommandParameterAttribute>().FirstOrDefault()
                             from parameter in new[] { attribute?.Short, attribute?.Value, property.Name }
                             where !string.IsNullOrWhiteSpace(parameter)
                             select new
                             {
                                 Key = $"--{parameter}",
                                 Value = $"{section}:{property.Name}"
                             };
            var dictionary =
                properties.GroupBy(i => i.Key, Comparer)
                          .ToDictionary(i => i.Key, i => i.First().Value, Comparer)
                          ;
            return dictionary;
        }
    }
}
