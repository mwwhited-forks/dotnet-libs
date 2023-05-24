using Eliassen.System.ComponentModel;

namespace Eliassen.System.Linq
{
    public static class OrderDirectionsExtensions
    {
        public const string Ascending = nameof(OrderDirections.Ascending);
        public const string AscendingShort = "asc";
        public const string Descending = nameof(OrderDirections.Descending);
        public const string DescendingShort = "desc";
    }
    public enum OrderDirections
    {
        [EnumValue(OrderDirectionsExtensions.AscendingShort)]
        Ascending = 0,
        [EnumValue(OrderDirectionsExtensions.DescendingShort)]
        Descending = 1,
    }
}
