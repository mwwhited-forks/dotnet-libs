using Eliassen.System.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace Eliassen.System.Reflection
{
    public static class EnumExtensions
    {
        public static string? AsString<TEnum>(this TEnum? input) where TEnum : struct, Enum =>
            AsModels<TEnum>().FirstOrDefault(e => e.Value.Equals(input))?.Name;

        public static TEnum ToEnum<TEnum>(this int input) where TEnum : struct, Enum =>
            (TEnum)(object)input;

        public static TEnum? ToEnum<TEnum>(this string? input) where TEnum : struct, Enum
        {
            if (string.IsNullOrWhiteSpace(input)) return default;
            else if (Enum.TryParse<TEnum>(input?.Replace('|', ','), out var parsed)) return parsed;

            var enumModel = AsModels<TEnum>();
            var enumValues = input.Split('|', ',');

            var map = from m in enumModel
                      from v in enumValues
                      where m.PossibleNames.Contains(v)
                      select m;

            if (!map.Any()) return default;

            var composed = map.Aggregate(0, (i, v) => i | v.Id);
            var result = composed.ToEnum<TEnum>();
            return result;
        }

        private static string? First(params string?[] values) =>
            (values ?? Array.Empty<string?>()).FirstOrDefault(v => !string.IsNullOrWhiteSpace(v));

        /// <summary>
        /// List enumerations values
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static IReadOnlyCollection<IEnumModel> AsModels<TEnum>() where TEnum : struct, Enum =>
            (
            from v in Enum.GetValues(typeof(TEnum)).Cast<TEnum>()
            let member = v.GetType().GetMember(Enum.GetName(v.GetType(), v)).FirstOrDefault()
            let description = member?.GetCustomAttributes<DescriptionAttribute>()?.FirstOrDefault()?.Description
            let displayValues = member?.GetCustomAttributes<DisplayAttribute>()?.FirstOrDefault()

            let enumValue = member?.GetCustomAttributes<EnumValueAttribute>()?.FirstOrDefault()
            let enumMember = member?.GetCustomAttributes<EnumMemberAttribute>()?.FirstOrDefault()

            let isEndState = member?.GetCustomAttributes<EndStateAttribute>()?.Any() ?? false
            let isExcludeFromUnique = member?.GetCustomAttributes<ExcludeFromUniqueAttribute>()?.Any() ?? false
            select new EnumModel<TEnum>
            {
                Id = Convert.ToInt32(v),

                Name = First(displayValues?.Name, v.ToString().Replace("_", " ")) ??
                    throw new NullReferenceException(nameof(EnumModel<TEnum>.Name)),
                Code = First(displayValues?.ShortName, v.ToString().ToUpper()) ??
                    throw new NullReferenceException(nameof(EnumModel<TEnum>.Code)),
                Description = First(description, displayValues?.Description),
                Order = displayValues?.GetOrder() ?? 0,

                Value = v,

                IsEndState = isEndState,
                IsExcludeFromUnique = isExcludeFromUnique,

                PossibleNames = new[]
                {
                    v.ToString(),
                    v.ToString().Replace("_", " "),
                    v.ToString().ToUpper(),
                    displayValues?.Name,
                    displayValues?.ShortName,
                    description,
                    displayValues?.Description,
                    enumValue?.Name,
                    enumMember?.Value,
                }.Where(s => !string.IsNullOrWhiteSpace(s)).OfType<string>().ToArray()
            }
            ).ToArray();
    }
}
