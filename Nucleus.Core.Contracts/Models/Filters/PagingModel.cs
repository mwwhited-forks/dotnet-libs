namespace Nucleus.Core.Contracts.Models.Filters
{
#warning Retire this
    public class PagingModel
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string? SortBy { get; set; }
        public string? SortDirection { get; set; }
        public bool ExcludePageCount { get; }
    }
}
