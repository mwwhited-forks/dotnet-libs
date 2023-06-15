using System;

namespace Nucleus.Core.Contracts.Models.Filters
{
#warning Retire this
    public class DocumentsFilter
    {
        public DocumentFilterItem? DocumentsFilters { get; set; }
        public PagingModel? PagingModel { get; set; }
    }

#warning Retire this
    public class DocumentFilterItem
    {
        public string? DocumentId { get; set; }
        public string? DocumentKey { get; set; }
        public string? DocumentName { get; set; }
        public string? DocumentType { get; set; }
        public DateTimeOffset? CreatedOnAfter { get; set; }
        public DateTimeOffset? CreatedOnBefore { get; set; }
    }
}
