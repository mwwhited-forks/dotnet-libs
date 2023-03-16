using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleus.Core.Contracts.Interfaces
{
    public interface IPageQuery
    {
        int CurrentPage { get; }
        int PageSize { get; }
        bool ExcludePageCount { get; }
    }
}
