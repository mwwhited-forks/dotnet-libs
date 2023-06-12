namespace Nucleus.Core.Persistence.Models.Filters
{
#warning Retire this
    public class UsersFilter
    {
        public UserFilterItem UserFilters { get; set; } = new();
        public PagingModel PagingModel { get; init; } = new ();
    }
}
