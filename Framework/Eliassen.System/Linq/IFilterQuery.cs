using System.Collections.Generic;

namespace Eliassen.System.Linq
{
    public interface IFilterQuery
    {
        IDictionary<string, object>? Filter { get; }
    }
}
