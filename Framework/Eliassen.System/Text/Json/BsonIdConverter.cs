using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Eliassen.System.Text.Json
{
    public class BsonIdConverter : JsonConverter<string>
    {
        public override string? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var type = reader.TokenType;

            if (type == JsonTokenType.StartObject)
            {
                if (reader.Read() && reader.TokenType == JsonTokenType.PropertyName && reader.GetString() == "$oid")
                {
                    if (reader.Read() && reader.TokenType == JsonTokenType.String)
                    {
                        var ret = reader.GetString();
                        reader.Read();
                        return ret;
                    }
                }
            }
            else if (type == JsonTokenType.String)
            {
                var ret = reader.GetString();
                //reader.Read();
                return ret;
            }

            throw new NotSupportedException($"element of type {type} is not supported");
        }

        public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteString("$oid", value);
            writer.WriteEndObject();
        }
    }
}
