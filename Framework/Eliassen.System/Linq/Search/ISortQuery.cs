using System.Collections.Generic;

namespace Eliassen.System.Linq.Search
{
    public interface ISortQuery
    {
        IDictionary<string, OrderDirections> OrderBy { get; }
    }
}
