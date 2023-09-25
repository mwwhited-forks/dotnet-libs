using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace Eliassen.System.Text.Json;

public class BsonTypeInfoResolver : DefaultJsonTypeInfoResolver
{
    public override JsonTypeInfo GetTypeInfo(Type type, JsonSerializerOptions options)
    {
        var info = base.GetTypeInfo(type, options);
        var idConvention = 
            (
            type.Name.EndsWith("Model") ? type.Name[..^5] :
            type.Name.EndsWith("Collection") ? type.Name[..^10] :
            type.Name
            ) + "Id";

        foreach (var prop in info.Properties)
        {
            if (string.Equals(prop.Name, idConvention, StringComparison.InvariantCultureIgnoreCase))
            {
                prop.Name = "_id";
                prop.CustomConverter = new BsonIdConverter();
            }
            else if (new[] {
                typeof(DateTime), 
                typeof(DateTime?),
                typeof(DateTimeOffset),
                typeof(DateTimeOffset?),
            }.Contains(prop.PropertyType))
            {
                prop.CustomConverter = new BsonDateTimeOffsetConverter();
            }
        }

        return info;
    }
}
