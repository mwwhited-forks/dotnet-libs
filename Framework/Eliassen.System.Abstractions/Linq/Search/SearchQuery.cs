using System.Text;

namespace Eliassen.System.Linq.Search
{
    public record SearchQuery<TModel> : SearchQuery, ISearchQuery<TModel>
    {
    }

    public record SearchQuery : ISearchQuery
    {
        internal static class Messages
        {
            public const string NoSearchQueryFilter = $"No filtering detected";
            public const string NoSearchQueryFilterCode = "NO_SEARCHQUERY_FILTER";

            public const string NoPropertyFilter = $"No filtering for property";
            public const string NoPropertyFilterCode = "NO_PROPERTY_FILTER";

            public const string SortPropertiesNotFound = $"Sort properties not found on model";
            public const string SortPropertiesNotFoundCode = "SORT_PROPERTY_NOT_FOUND";

            public const string ApplySortDefault = $"Applying Default Sort Order";
            public const string ApplySortDefaultCode = "SORT_DEFAULT_APPLIED";

            public const string ForceSortDefault = $"Forcing Sort Order";
            public const string ForceSortDefaultCode = "SORT_DEFAULT_FORCED";
        }

        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public bool ExcludePageCount { get; set; }
        public string? SearchTerm { get; set; }
        public Dictionary<string, FilterParameter> Filter { get; init; } = [];
        public Dictionary<string, OrderDirections> OrderBy { get; init; } = [];

        IDictionary<string, FilterParameter> IFilterQuery.Filter => Filter;
        IDictionary<string, OrderDirections> ISortQuery.OrderBy => OrderBy;

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{nameof(CurrentPage)}: {CurrentPage}");
            sb.AppendLine($"{nameof(PageSize)}: {PageSize}");
            sb.AppendLine($"{nameof(ExcludePageCount)}: {ExcludePageCount}");
            sb.AppendLine($"{nameof(SearchTerm)}: {SearchTerm ?? "(null)"}");

            foreach (var item in Filter ?? [])
            {
                sb.AppendLine($"\tF:{item.Key}: {item.Value}");
            }
            foreach (var item in OrderBy ?? [])
            {
                sb.AppendLine($"\tS:{item.Key}: {item.Value}");
            }
            return sb.ToString();
        }
    }
}
