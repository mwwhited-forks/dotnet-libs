using System.Collections.Generic;

namespace Eliassen.System.Linq
{
    public static class DictionaryExtensions
    {
        public static bool TryGetValue<TKey, TValue>(
            this IDictionary<TKey, TValue> dict, 
            TKey key, 
            out TValue value, 
            IEqualityComparer<TKey> comparer
            )
            where TKey : notnull =>
            dict.ChangeComparer( comparer).TryGetValue(key, out value);

        public static IDictionary<TKey, TValue> ChangeComparer<TKey, TValue>(
            this IDictionary<TKey, TValue> dict,
            IEqualityComparer<TKey> comparer
            )
            where TKey : notnull => 
            new Dictionary<TKey, TValue>(dict, comparer);
    }
}
