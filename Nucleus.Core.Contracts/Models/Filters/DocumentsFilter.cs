using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleus.Core.Contracts.Models.Filters
{
    public class DocumentsFilter
    {
        public DocumentFilterItem? DocumentsFilters { get; set; }
        public PagingModel? PagingModel { get; set; }
    }

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
