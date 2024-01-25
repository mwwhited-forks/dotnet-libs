using Eliassen.System.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text.Json;

namespace Eliassen.System.Reflection;

/// <summary>
/// Extensions for reflection and common patterns.
/// </summary>
public static class ReflectionExtensions
{
    /// <summary>
    /// flag combination to select public instance properties
    /// </summary>
    public const BindingFlags PublicProperties = BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase;
    /// <summary>
    /// flag combination to select public static methods
    /// </summary>
    public const BindingFlags PublicStaticMethod = BindingFlags.Static | BindingFlags.Public | BindingFlags.InvokeMethod | BindingFlags.IgnoreCase;
    /// <summary>
    /// flag combination to select public instance methods
    /// </summary>
    public const BindingFlags PublicInstanceMethod = BindingFlags.Instance | BindingFlags.Public | BindingFlags.InvokeMethod | BindingFlags.IgnoreCase;

    /// <summary>
    /// lookup key values for provided entity 
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public static object? GetKeyValue(this object item)
    {
        var properties = item.GetType().GetPropertiesByAttribute<KeyAttribute>();
        var keys = properties.Select(i => i.GetValue(item)).ToArray();
        return keys.Length == 1 ? keys[0] : keys;
    }

    /// <summary>
    /// safely create new array for a given element type.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="inputs"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Make safe will try to convert input to target type as best as possible.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="input"></param>
    /// <returns></returns>
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
            return enumValue ?? default;
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

    /// <summary>
    /// Use best possible match for parsing to provided type
    /// </summary>
    /// <param name="type"></param>
    /// <param name="toParse"></param>
    /// <param name="parsed"></param>
    /// <returns></returns>
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
            .GetMethod(name: "Parse", bindingAttr: PublicStaticMethod, binder: null, [typeof(string)], modifiers: null)
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

    /// <summary>
    /// Type name with full namespace, name and assembly.  version is not included
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static string GetShortTypeName(this Type type) =>
        $"{type.FullName}, {type.Assembly.GetName().Name}";

    /// <summary>
    /// Get all attributes for type
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static IEnumerable<Attribute> GetAttributes(this Type type) =>
        TypeDescriptor.GetAttributes(type).OfType<Attribute>();

    /// <summary>
    /// Get all attributes of selected style for reflected type
    /// </summary>
    /// <typeparam name="TAttribute"></typeparam>
    /// <param name="type"></param>
    /// <returns></returns>
    public static IEnumerable<TAttribute> GetAttributes<TAttribute>(this Type type) =>
        type.GetAttributes().OfType<TAttribute>();

    /// <summary>
    /// get property info where attribute matches
    /// </summary>
    /// <typeparam name="TAttribute"></typeparam>
    /// <param name="type"></param>
    /// <returns></returns>
    public static IEnumerable<PropertyDescriptor> GetPropertiesByAttribute<TAttribute>(this Type type)
        where TAttribute : Attribute =>
        from p in TypeDescriptor.GetProperties(type).OfType<PropertyDescriptor>()
        where p.Attributes.OfType<TAttribute>().Any()
        select p;

    /// <summary>
    /// get static method
    /// </summary>
    /// <param name="type"></param>
    /// <param name="methodName"></param>
    /// <param name="parameterTypes"></param>
    /// <returns></returns>
    public static MethodInfo? GetStaticMethod(this Type type, string methodName, params Type[] parameterTypes) =>
         type.GetMethod(name: methodName, bindingAttr: PublicStaticMethod, types: parameterTypes) switch
         {
             MethodInfo method when method.GetParametersTypes().SequenceEqual(parameterTypes) => method,
             _ => default
         };

    /// <summary>
    /// get instance method
    /// </summary>
    /// <param name="type"></param>
    /// <param name="methodName"></param>
    /// <param name="parameterTypes"></param>
    /// <returns></returns>
    public static MethodInfo? GetInstanceMethod(this Type type, string methodName, params Type[] parameterTypes) =>
         type.GetMethod(name: methodName, bindingAttr: PublicInstanceMethod, types: parameterTypes) switch
         {
             MethodInfo method when method.GetParametersTypes().SequenceEqual(parameterTypes) => method,
             _ => default
         };

    /// <summary>
    /// get parameters for method
    /// </summary>
    /// <param name="method"></param>
    /// <returns></returns>
    public static IEnumerable<Type> GetParametersTypes(this MethodInfo method) =>
         method.GetParameters().Select(p => p.ParameterType);
}
