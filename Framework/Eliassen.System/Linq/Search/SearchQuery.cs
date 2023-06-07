using System.Collections.Generic;
using System.Text;

namespace Eliassen.System.Linq.Search
{
    /// <inheritdoc/>
    public record SearchQuery<TModel> : SearchQuery, ISearchQuery<TModel>
    {
    }

    /// <inheritdoc/>
    public record SearchQuery : ISearchQuery
    {
        /// <inheritdoc cref="IPageQuery.CurrentPage"/>
        public int CurrentPage { get; set; }
        /// <inheritdoc cref="IPageQuery.PageSize"/>
        public int PageSize { get; set; }
        /// <inheritdoc cref="IPageQuery.ExcludePageCount"/>
        public bool ExcludePageCount { get; set; }

        /// <inheritdoc cref="ISearchTermQuery.SearchTerm"/>
        public string? SearchTerm { get; set; }

        /// <inheritdoc cref="IFilterQuery.Filter"/>
        public Dictionary<string, FilterParameter> Filter { get; init; } = new();

        /// <inheritdoc cref="ISortQuery.OrderBy"/>
        public Dictionary<string, OrderDirections> OrderBy { get; init; } = new();

        IDictionary<string, FilterParameter> IFilterQuery.Filter => Filter;
        IDictionary<string, OrderDirections> ISortQuery.OrderBy => OrderBy;

        /// <inheritdoc />
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{nameof(CurrentPage)}: {CurrentPage}");
            sb.AppendLine($"{nameof(PageSize)}: {PageSize}");
            sb.AppendLine($"{nameof(ExcludePageCount)}: {ExcludePageCount}");
            sb.AppendLine($"{nameof(SearchTerm)}: {SearchTerm ?? "(null)"}");

            foreach (var item in Filter ?? new Dictionary<string, FilterParameter>())
            {
                sb.AppendLine($"\tF:{item.Key}: {item.Value}");
            }
            foreach (var item in OrderBy ?? new Dictionary<string, OrderDirections>())
            {
                sb.AppendLine($"\tS:{item.Key}: {item.Value}");
            }
            return sb.ToString();
        }
    }
}
