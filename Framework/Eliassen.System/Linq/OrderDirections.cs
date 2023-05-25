using Eliassen.System.ComponentModel;

namespace Eliassen.System.Linq
{
    public enum OrderDirections
    {
        [EnumValue(OrderDirectionsExtensions.AscendingShort)]
        Ascending = 0,
        [EnumValue(OrderDirectionsExtensions.DescendingShort)]
        Descending = 1,
    }
}
