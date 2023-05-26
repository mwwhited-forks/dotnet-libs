using System.Text.Json.Serialization;

namespace Eliassen.System.Linq
{
    public record SearchParameter
    {
        [JsonPropertyName("eq")]
        public object? EqualTo { get; set; }

        [JsonPropertyName("in")]
        public object?[]? InSet { get; set; }

        [JsonPropertyName("gt")]
        public object? GreaterThan { get; set; }
        [JsonPropertyName("gte")]
        public object? GreaterThanOrEqualTo { get; set; }

        [JsonPropertyName("lt")]
        public object? LessThan { get; set; }
        [JsonPropertyName("lte")]
        public object? LessThanOrEqualTo { get; set; }
    }
}
