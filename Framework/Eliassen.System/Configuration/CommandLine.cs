using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Eliassen.System.Configuration
{
    public static class CommandLine
    {
        public static IDictionary<string, string> AddParameters<T>(this IDictionary<string, string> items) =>
            items.Concat(BuildParameters<T>()).GroupBy(i => i.Key).ToDictionary(i => i.Key, i => i.First().Value);

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
            return properties.GroupBy(i => i.Key).ToDictionary(i => i.Key, i => i.First().Value);
        }

        public static IDictionary<string, string> ToDictionary(this IEnumerable<(string key, string value)> items) =>
            items.GroupBy(i => i.key).ToDictionary(i => i.Key, i => i.First().value);
    }
}
