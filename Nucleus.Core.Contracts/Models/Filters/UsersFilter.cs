using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleus.Core.Contracts.Models.Filters
{
    public class UsersFilter
    {
        public UserFilterItem? UserFilters { get; set; }
        public PagingModel PagingModel { get; set; }
    }

    public class UserFilterItem
    {
        public string? InputValue { get; set; }
        public string? Module { get; set; }
        public string? UserStatus { get; set; }
    }
}
