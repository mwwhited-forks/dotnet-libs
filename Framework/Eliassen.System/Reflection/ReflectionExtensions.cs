using Eliassen.System.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text.Json;

namespace Eliassen.System.Reflection
{
    public static class ReflectionExtensions
    {
        public const BindingFlags PublicProperties = BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance;
        public const BindingFlags PublicStaticMethod = BindingFlags.Static | BindingFlags.Public | BindingFlags.InvokeMethod;
        public const BindingFlags PublicInstanceMethod = BindingFlags.Instance | BindingFlags.Public | BindingFlags.InvokeMethod;

        public static object? MakeSafeArray(this Type? type, Array? inputs)
        {
            if (type == null || inputs == null)
            {
                return default;
            }

            var results = new List<object>();
            foreach (var input in inputs)
            {
                var value = type.MakeSafe(input);
                if (value != null)
                {
                    results.Add(value);
                }
            }

            var safeArray = Array.CreateInstance(type, results.Count);
            var resultsArray = results.ToArray();
            Array.Copy(resultsArray, safeArray, resultsArray.Length);
            return safeArray;
        }

        public static object? MakeSafe(this Type? type, object? input)
        {
            if (type == null || input == null)
                return default;
            else if (type.IsInstanceOfType(input))
                return input;
            else if (input is string inputString)
            {
                if (TryParse(type, inputString, out var parsed) && parsed != null)
                {
                    return parsed;
                }
                if (type == typeof(byte[]))
                {
                    try
                    {
                        return Convert.FromBase64String(inputString);
                    }
                    catch { }
                }
            }
            else if (type.IsEnum && input is int enumInt)
            {
                var enumName = Enum.GetName(type, enumInt);
                var enumValue = MakeSafe(type, enumName);
                if (enumValue != null) return enumValue;
                return default;
            }
            else if (input.GetType().IsValueType && type == typeof(string))
                return input.ToString();
            else if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                return MakeSafe(type.GetGenericArguments()[0], input);

            try
            {
                if (input is IConvertible convertible)
                {
                    return Convert.ChangeType(convertible, type);
                }
                else if (input is JsonElement json)
                {
                    return JsonSerializer.Deserialize(json, type);
                }
                else
                {
                    var to = TypeDescriptor.GetConverter(type);
                    if (to.CanConvertFrom(input.GetType()))
                    {
                        return to.ConvertFrom(input);
                    }

                    var from = TypeDescriptor.GetConverter(input);
                    if (from.CanConvertTo(type))
                    {
                        return from.ConvertTo(input, type);
                    }
                }
            }
            catch
            {
                //TODO: should probably do something smarter
            }

            return default;
        }

        public static bool TryParse(this Type? type, string? toParse, out object? parsed)
        {
            if (type == null || string.IsNullOrWhiteSpace(toParse))
            {
                parsed = default;
                return false;
            }

            if (type.IsEnum)
            {
                if (Enum.TryParse(type, toParse, ignoreCase: true, out var value) && value != null)
                {
                    parsed = value;
                    return true;
                }
                else
                {
                    var enumValues = from ev in type.GetFields()
                                     where ev.FieldType == type
                                     let desc = ev.GetCustomAttribute<DescriptionAttribute>()?.Description
                                     let enumVale = ev.GetCustomAttribute<EnumValueAttribute>()?.Name
                                     where toParse.Equals(desc, StringComparison.InvariantCultureIgnoreCase) ||
                                           toParse.Equals(enumVale, StringComparison.InvariantCultureIgnoreCase)
                                     select ev.GetValue(null);
                    var enumValue = enumValues.FirstOrDefault();
                    if (enumValue != null)
                    {
                        parsed = enumValue;
                        return true;
                    }
                }
            }

            var parseMethod = type
                .GetMethod(name: "Parse", bindingAttr: PublicStaticMethod, binder: null, new[] { typeof(string) }, modifiers: null)
                ;

            if (parseMethod != null)
            {
                try
                {
                    var value = parseMethod.Invoke(null, new[] { toParse });
                    if (value != null)
                    {
                        parsed = value;
                        return true;
                    }
                }
                catch
                {
                    //Intentional
                }
            }

            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                if (TryParse(type.GetGenericArguments()[0], toParse, out var value))
                {
                    parsed = value;
                    return true;
                }
            }

            parsed = default;
            return false;
        }

        public static string GetShortTypeName(this Type type) =>
            $"{type.FullName}, {type.Assembly.GetName().Name}";

        public static IEnumerable<Attribute> GetAttributes(this Type type) =>
            TypeDescriptor.GetAttributes(type).OfType<Attribute>();

        public static IEnumerable<Attribute> GetAttributes(this object @object) =>
            TypeDescriptor.GetAttributes(@object).OfType<Attribute>();

        public static IEnumerable<TAttribute> GetAttributes<TAttribute>(this Type type)
            where TAttribute : Attribute =>
            type.GetAttributes().OfType<TAttribute>();

        public static IEnumerable<TAttribute> GetAttributes<TAttribute>(this object @object)
            where TAttribute : Attribute =>
            @object.GetAttributes().OfType<TAttribute>();
    }
}
