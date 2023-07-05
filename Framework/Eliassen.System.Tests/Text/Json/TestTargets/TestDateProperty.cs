using Eliassen.System.Text.Json;
using System;
using System.Text.Json.Serialization;

namespace Eliassen.System.Tests.Text.Json.TestTargets;

public class TestDateProperty
{
    [JsonConverter(typeof(BsonDateConverter))]
    public DateTimeOffset? Nullable { get; set; }

    [JsonConverter(typeof(BsonDateConverter))]
    public DateTimeOffset Value { get; set; }
}
