using Eliassen.System.Linq.Search;

namespace Nucleus.Core.Contracts.Models
{
    public class PagingModel : IPageQuery
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string? SortBy { get; set; }
        public string? SortDirection { get; set; }
        public bool ExcludePageCount { get; }

        public static PagingModel Default => new PagingModel { CurrentPage = 1, PageSize = 10 };
    }
}
