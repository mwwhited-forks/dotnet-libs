using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleus.Core.Persistence.Models.DbSettings
{
    public class DocumentDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string DocumentsCollectionName { get; set; } = null!;
    }
}
