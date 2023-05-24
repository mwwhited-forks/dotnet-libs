using System.Collections.Generic;

namespace Eliassen.System.Linq
{
    public interface ISortQuery
    {
        IDictionary<string, OrderDirections> OrderBy { get; }
    }
}
