using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Eliassen.System.Linq
{
    /// <summary>
    /// Reusable extensions for Generic Dictionaries
    /// </summary>
    public static class DictionaryExtensions
    {
        /// <summary>
        /// extend try get value to allow for using a different IEqualityComparer{TKey}
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public static bool TryGetValue<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            TKey key,
            out TValue? value,
            IEqualityComparer<TKey> comparer
            )
            where TKey : notnull =>
            dictionary.ChangeComparer(comparer).TryGetValue(key, out value);

        /// <summary>
        /// Rebuild dictionary to use a different IEqualityComparer{TKey}
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public static IDictionary<TKey, TValue> ChangeComparer<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            IEqualityComparer<TKey> comparer
            )
            where TKey : notnull =>
            new Dictionary<TKey, TValue>(dictionary, comparer);



        //internal class WrappedDictionary<TKey, TValue> : IDictionary<TKey, TValue>
        //    where TKey : notnull
        //{
        //    private readonly IDictionary<TKey, TValue> _wrapped;
        //    private readonly IDictionary<TKey, TValue> _indexed;
        //    private readonly IEqualityComparer<TKey> _comparer;

        //    public WrappedDictionary(
        //        IDictionary<TKey, TValue> dictionary,
        //        IEqualityComparer<TKey> comparer
        //        )
        //    {
        //        _wrapped = dictionary;
        //        _indexed = new Dictionary<TKey, TValue>(dictionary, comparer);
        //        _comparer = comparer;
        //    }

        //    public TValue this[TKey key]
        //    {
        //        get => _indexed[key];
        //        set
        //        {
        //            if (!_wrapped.IsReadOnly) throw new NotSupportedException();
        //            _indexed[key] = value;
        //            var wrappedKey = _wrapped.Keys.First(k => _comparer.Equals(key, k));
        //            _wrapped[wrappedKey] = value;
        //        }
        //    }

        //    public ICollection<TKey> Keys => _wrapped.Keys;
        //    public ICollection<TValue> Values => _wrapped.Values;
        //    public int Count => _wrapped.Count;
        //    public bool IsReadOnly => _wrapped.IsReadOnly;

        //    public void Add(TKey key, TValue value)
        //    {
        //        if (!_wrapped.IsReadOnly) throw new NotSupportedException();
        //        _wrapped.Add(key, value);
        //        _indexed.Add(key, value);
        //    }

        //    public void Add(KeyValuePair<TKey, TValue> item)
        //    {
        //        if (!_wrapped.IsReadOnly) throw new NotSupportedException();
        //        _wrapped.Add(item);
        //        _indexed.Add(item);
        //    }

        //    public void Clear()
        //    {
        //        if (!_wrapped.IsReadOnly) throw new NotSupportedException();
        //        _wrapped.Clear();
        //        _indexed.Clear();
        //    }

        //    public bool Contains(KeyValuePair<TKey, TValue> item) => _indexed.Contains(item);
        //    public bool ContainsKey(TKey key) => _indexed.ContainsKey(key);

        //    public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) =>
        //        _wrapped.CopyTo(array, arrayIndex);

        //    public bool Remove(TKey key)
        //    {
        //        if (_indexed.ContainsKey(key))
        //        {
        //            var wrappedKey = _wrapped.Keys.FirstOrDefault(k => _comparer.Equals(key, k));
        //            if (wrappedKey != null)
        //            {
        //                return _indexed.Remove(key) && _wrapped.Remove(wrappedKey);
        //            }
        //        }

        //        return false;
        //    }

        //    public bool Remove(KeyValuePair<TKey, TValue> item)
        //    {
        //        if (_indexed.ContainsKey(item.Key))
        //        {
        //            var wrappedKey = _wrapped.Keys.FirstOrDefault(k => _comparer.Equals(item.Key, k));
        //            if (wrappedKey != null)
        //            {
        //                return _indexed.Remove(item) && _wrapped.Remove(new KeyValuePair<TKey, TValue>(wrappedKey, item.Value));
        //            }
        //        }

        //        return false;
        //    }

        //    public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
        //    {
        //        return _wrapped.TryGetValue(key, out value);
        //    }

        //    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => _wrapped.GetEnumerator();
        //    IEnumerator IEnumerable.GetEnumerator() => _wrapped.GetEnumerator();
        //}
    }
}
