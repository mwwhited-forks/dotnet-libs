using Eliassen.System.ComponentModel;
using Eliassen.System.Text.Json.Serialization;
using System.Text.Json.Serialization;

namespace Eliassen.System.Linq.Search
{
    [JsonConverter(typeof(JsonStringEnumConverterEx<OrderDirections>))]
    public enum OrderDirections
    {
        [EnumValue(OrderDirectionsConstants.AscendingShort)]
        Ascending = 0,
        [EnumValue(OrderDirectionsConstants.DescendingShort)]
        Descending = 1,
    }
}
