using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eliassen.Extensions.Linq;

/// <summary>
/// Provides extension methods for asynchronous enumerables.
/// </summary>
public static class EnumerableExtensions
{
    /// <summary>
    /// Converts an asynchronous enumerable sequence to a set (IEnumerable{T}) asynchronously.
    /// </summary>
    /// <typeparam name="T">The type of elements in the sequence.</typeparam>
    /// <param name="items">The asynchronous enumerable sequence to convert.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the set of elements in the sequence.</returns>
    public static async Task<IEnumerable<T>> ToSetAsync<T>(this IAsyncEnumerable<T> items)
    {
        var result = new List<T>();
        await foreach (var item in items)
            result.Add(item);
        return result;
    }
}
