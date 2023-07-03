using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Eliassen.System.Text.Json
{
    public class BsonDateConverter : JsonConverter<DateTimeOffset>
    {
        public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var type = reader.TokenType;

            if (type == JsonTokenType.StartObject)
            {
                if (reader.Read() && reader.TokenType == JsonTokenType.PropertyName && reader.GetString() == "$date")
                {
                    if (reader.Read())
                    {
                        if (reader.TokenType == JsonTokenType.String && reader.TryGetDateTimeOffset(out var dt))
                        {
                            reader.Read();
                            return dt;
                        }
                    }
                }
            }
            else if (type == JsonTokenType.String && reader.TryGetDateTimeOffset(out var dt))
            {
                return dt;
            }

            throw new NotSupportedException($"element of type {type} is not supported");
        }

        public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteString("$date", value);
            writer.WriteEndObject();
        }
    }
}
