using System.Collections.Generic;

namespace Eliassen.System.Linq.Search
{
    public interface IFilterQuery
    {
        IDictionary<string, SearchParameter>? Filter { get; }
    }
}
