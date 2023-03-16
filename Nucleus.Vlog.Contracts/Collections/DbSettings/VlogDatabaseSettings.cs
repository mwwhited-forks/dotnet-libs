﻿namespace Nucleus.Vlog.Contracts.Collections.DbSettings
{
    public class VlogDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string VlogsCollectionName { get; set; } = null!;
    }
}
