using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Eliassen.System.Linq;

/// <summary>
/// Extensions to add async support to existing IEnumerable{T}
/// </summary>
public static class AsyncEnumerableExtensions
{
    /// <summary>
    /// Process IQueryable{T} to a List{T} as async
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    /// <param name="source"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<List<TModel>> ToListAsync<TModel>(
        this IQueryable<TModel> source,
        CancellationToken cancellationToken = default
        )
    {
        // copied from EF Core 
        // https://github.com/dotnet/efcore/blob/main/src/EFCore/Extensions/EntityFrameworkQueryableExtensions.cs
        var list = new List<TModel>();
        await foreach (var element in source.AsAsyncEnumerable(cancellationToken))
        {
            list.Add(element);
        }

        return list;
    }

    /// <summary>
    /// Convert IAsyncEnumerable{TModel} to Task{IEnumerable{TModel}}
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    /// <param name="items"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    public static async Task<IEnumerable<TModel>> AsEnumerableAsync<TModel>(
        this IAsyncEnumerable<TModel> items,
        CancellationToken token = default
        )
    {
        var list = new List<TModel>();
        await foreach (var item in items)
        {
            if (token.IsCancellationRequested) break;
            list.Add(item);
        }
        return list.AsReadOnly();
    }

    /// <summary>
    /// Convert Task{IEnumerable{TModel}} to IAsyncEnumerable{TModel}
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    /// <param name="items"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async IAsyncEnumerable<TModel> AsAsyncEnumerable<TModel>(
        this Task<IEnumerable<TModel>> items,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
        )
    {
        foreach (var item in await items)
        {
            if (cancellationToken.IsCancellationRequested) break;
            yield return item;
            await Task.Yield();
        }
    }

    /// <summary>
    /// Convert IEnumerable{TModel} to IAsyncEnumerable{TModel}
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    /// <param name="items"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async IAsyncEnumerable<TModel> AsAsyncEnumerable<TModel>(
        this IEnumerable<TModel> items,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        // Modified from EF Core to also enable Async iteration over enumerable that are not natively async.  
        if (items is IAsyncEnumerable<TModel> asyncItems)
        {
            await foreach (var item in asyncItems)
            {
                if (cancellationToken.IsCancellationRequested) break;
                yield return item;
            }
        }
        else
        {
            foreach (var item in items)
            {
                if (cancellationToken.IsCancellationRequested) break;
                yield return item;
                await Task.Yield();
            }
        }
    }
}
