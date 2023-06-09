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
            await foreach (var element in source.AsAsyncEnumerable(cancellationToken))
            {
                list.Add(element);
            }

            return list;
        }

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

        public static async IAsyncEnumerable<TModel> AsAsyncEnumerable<TModel>(
            this IEnumerable<TModel> items,
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            // Modified from EF Core to also enable Async iteration over enumerables that are not natively async.  
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
}
