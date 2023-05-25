using System.Collections.Generic;

namespace Eliassen.System.Linq
{
    public interface IFilterQuery
    {
        IDictionary<string, SearchOption>? Filter { get; }
    }
}
