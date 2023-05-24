using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Eliassen.System.Linq
{
    public static class EnumerableExtensions
    {
        public static async Task<List<TModel>> ToListAsync<TModel>(
            this IQueryable<TModel> source,
            CancellationToken cancellationToken = default
            )
        {
            // copied from EF Core 
            // https://github.com/dotnet/efcore/blob/main/src/EFCore/Extensions/EntityFrameworkQueryableExtensions.cs
            var list = new List<TModel>();
            await foreach (var element in source.AsAsyncEnumerable().WithCancellation(cancellationToken))
            {
                list.Add(element);
            }

            return list;
        }

        public static async IAsyncEnumerable<TModel> AsAsyncEnumerable<TModel>(
            this IEnumerable<TModel> items,
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            // Modified from EF Core to also enable Async iteration over enumerables that are not natively async.  
            if (items is IAsyncEnumerable<TModel> asyncItems)
            {
                //    var enumerator = asyncItems.GetAsyncEnumerator(cancellationToken);
                //    await using var _ = enumerator.ConfigureAwait(false);
                //    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                //    {
                //        yield return enumerator.Current;
                //    }
                await foreach (var item in asyncItems)
                {
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
}
