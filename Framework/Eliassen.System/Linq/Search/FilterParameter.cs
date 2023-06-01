using System.Text.Json.Serialization;

namespace Eliassen.System.Linq.Search
{
    /// <summary>
    /// Filter parameter
    /// </summary>
    public record FilterParameter
    {
        /// <summary>
        /// `Equal To`: pass in the value to match for a given property  
        /// 
        /// If you are using string values you may also use wild cards  
        /// \*bc -> Ends with  
        /// \*b\* -> Contains  
        /// ab\* -> Starts with
        /// </summary>
        [JsonPropertyName("eq")]
        public object? EqualTo { get; set; }

        /// <summary>
        /// `Not Equal To`: pass in the value to match for a given property  
        /// 
        /// If you are using string values you may also use wild cards  
        /// \*bc -> Ends with  
        /// \*b\* -> Contains  
        /// ab\* -> Starts with
        /// </summary>
        [JsonPropertyName("neq")]
        public object? NotEqualTo { get; set; }

        /// <summary>
        /// This allows for providing a set of values for filtering for multiple values
        /// </summary>
        [JsonPropertyName("in")]
        public object?[]? InSet { get; set; }

        /// <summary>
        /// `Greater than`
        /// </summary>
        [JsonPropertyName("gt")]
        public object? GreaterThan { get; set; }
        /// <summary>
        /// `Greater than or equal to`
        /// </summary>
        [JsonPropertyName("gte")]
        public object? GreaterThanOrEqualTo { get; set; }
        /// <summary>
        /// `Less than`
        /// </summary>
        [JsonPropertyName("lt")]
        public object? LessThan { get; set; }
        /// <summary>
        /// `Less than or equal to`
        /// </summary>
        [JsonPropertyName("lte")]
        public object? LessThanOrEqualTo { get; set; }
    }
}
