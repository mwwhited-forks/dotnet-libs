using Eliassen.System.Linq.Search;
using System.Linq;

namespace Nucleus.Core.Persistence.Models
{
#warning retire this
    public static class PagedLegacyExtensions
    {
        public static PagedResult<T> AsLegacy<T>(
            this IQueryResult<T> result,
            PagingModel? filter = default
            )
            where T : class
        {
            if (result is IPagedQueryResult<T> paged)
            {
                return new PagedResult<T>()
                {
                    CurrentPage = filter?.CurrentPage ?? 0,
                    PageCount = paged.TotalPageCount,
                    Results = result.Rows.ToList(),
                    PageSize = filter?.PageSize ?? 0,
                    RowCount = paged.TotalRowCount,
                };
            }
            else
            {
                return new PagedResult<T>()
                {
                    CurrentPage = filter?.CurrentPage ?? 0,
                    PageCount = -1,
                    Results = result.Rows.ToList(),
                    PageSize = filter?.PageSize ?? 0,
                    RowCount = result.Rows.Count,
                };

            }
        }
    }
}
