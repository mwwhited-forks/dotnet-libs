using Eliassen.System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Eliassen.System.Text.Json.Serialization
{
    public class JsonStringEnumConverterEx<TEnum> : JsonConverter<TEnum> where TEnum : struct, Enum
    {
        public override TEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var type = reader.TokenType;
            if (type == JsonTokenType.String)
            {
                var value = reader.GetString();
                var enumValue = value.ToEnum<TEnum>();
                return enumValue ?? default;
            }
            else if (type == JsonTokenType.Number)
            {
                var value = reader.GetInt32();
                var enumValue = value.ToEnum<TEnum>();
                return enumValue;
            }

            return default;
        }

        public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(EnumExtensions.AsString<TEnum>(value));
        }
    }
}
