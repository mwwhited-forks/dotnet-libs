using Eliassen.System.ComponentModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Runtime.Serialization;

namespace Eliassen.System.Reflection
{
    public static class EnumExtensions
    {
        private static string? First(params string?[] values) =>
            (values ?? Array.Empty<string?>()).FirstOrDefault(v => !string.IsNullOrWhiteSpace(v));

        public static string? AsString<TEnum>(this TEnum input) where TEnum : struct, Enum =>
            input.AsModel()?.Code;

        public static TEnum ToEnum<TEnum>(this int input) where TEnum : struct, Enum =>
            (TEnum)(object)input;

        public static TEnum? ToEnum<TEnum>(this string? input) where TEnum : struct, Enum
        {
            if (string.IsNullOrWhiteSpace(input)) return default;
            else if (Enum.TryParse<TEnum>(input?.Replace('|', ','), out var parsed)) return parsed;

            var enumModel = AsModels<TEnum>();
            var enumValues = input?.Split('|', ',') ?? Array.Empty<string>();

            var map = from m in enumModel
                      from v in enumValues
                      where m.PossibleNames.Contains(v)
                      select m;

            if (!map.Any()) return default;

            var composed = map.Aggregate(0, (i, v) => i | v.Id);
            var result = composed.ToEnum<TEnum>();
            return result;
        }

        public static IEnumModel<TEnum>? AsModel<TEnum>(this TEnum @enum) where TEnum : struct, Enum
        {
            var enumName = Enum.GetName(typeof(TEnum), @enum);
            if (string.IsNullOrEmpty(enumName)) return null;

            var member = @enum.GetType().GetMember(enumName).FirstOrDefault();
            var description = member?.GetCustomAttributes<DescriptionAttribute>()?.FirstOrDefault()?.Description;
            var displayValues = member?.GetCustomAttributes<DisplayAttribute>()?.FirstOrDefault();

            var enumValue = member?.GetCustomAttributes<EnumValueAttribute>()?.FirstOrDefault();
            var enumMember = member?.GetCustomAttributes<EnumMemberAttribute>()?.FirstOrDefault();

            var isEndState = member?.GetCustomAttributes<EndStateAttribute>()?.Any() ?? false;
            var isExcludeFromUnique = member?.GetCustomAttributes<ExcludeFromUniqueAttribute>()?.Any() ?? false;

            return new EnumModel<TEnum>
            {
                Id = Convert.ToInt32(@enum),

                Name = First(displayValues?.Name, @enum.ToString().Replace("_", " ")) ??
                    throw new NullReferenceException(nameof(EnumModel<TEnum>.Name)),
                Code = First(
                    enumValue?.Name,
                    enumMember?.Value,
                    displayValues?.ShortName,
                    displayValues?.Name,
                    @enum.ToString().ToUpper()) ??
                    throw new NullReferenceException(nameof(EnumModel<TEnum>.Code)),
                Description = First(description, displayValues?.Description),
                Order = displayValues?.GetOrder() ?? 0,

                Value = @enum,

                IsEndState = isEndState,
                IsExcludeFromUnique = isExcludeFromUnique,

                PossibleNames = new[]
                {
                    @enum.ToString(),
                    @enum.ToString().Replace("_", " "),
                    @enum.ToString().ToUpper(),
                    displayValues?.Name,
                    displayValues?.ShortName,
                    description,
                    displayValues?.Description,
                    enumValue?.Name,
                    enumMember?.Value,
                }.Where(s => !string.IsNullOrWhiteSpace(s)).OfType<string>().ToArray()
            };
        }

        /// <summary>
        /// List enumerations values
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static IReadOnlyCollection<IEnumModel> AsModels<TEnum>() where TEnum : struct, Enum =>
           Enum.GetValues(typeof(TEnum)).Cast<TEnum>().Select(AsModel).Where(e => e != null).ToArray();
    }
}
