using Eliassen.System.ComponentModel;
using Eliassen.System.Reflection;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Eliassen.System.Linq
{

    public class JsonStringEnumConverterEx<TEnum> : JsonConverter<TEnum> where TEnum : struct, global::System.Enum
    {
        public override TEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var type = reader.TokenType;
            if (type == JsonTokenType.String)
            {
                var value = reader.GetString();
                var enumValue = EnumExtensions.ToEnum<TEnum>(value);
                return enumValue ?? default;
            }
            else if (type == JsonTokenType.Number)
            {
                var value = reader.GetInt32();
                var enumValue = EnumExtensions.ToEnum<TEnum>(value);
                return enumValue ;
            }

            return default;
        }

        public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(EnumExtensions.AsString<TEnum>(value));
        }
    }

    [JsonConverter(typeof(JsonStringEnumConverterEx<OrderDirections>))]
    public enum OrderDirections
    {
        [EnumValue(OrderDirectionsExtensions.AscendingShort)]
        Ascending = 0,
        [EnumValue(OrderDirectionsExtensions.DescendingShort)]
        Descending = 1,
    }
}
