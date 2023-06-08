using System.Collections.Generic;

namespace Eliassen.System.Linq
{
    public static class DictionaryExtensions
    {
        public static bool TryGetValue<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary, 
            TKey key, 
            out TValue? value, 
            IEqualityComparer<TKey> comparer
            )
            where TKey : notnull =>
            dictionary.ChangeComparer( comparer).TryGetValue(key, out value);

        public static IDictionary<TKey, TValue> ChangeComparer<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            IEqualityComparer<TKey> comparer
            )
            where TKey : notnull => 
            new Dictionary<TKey, TValue>(dictionary, comparer);
    }
}
