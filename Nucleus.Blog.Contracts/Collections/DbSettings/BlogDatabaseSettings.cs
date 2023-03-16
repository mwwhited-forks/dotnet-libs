using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleus.Blog.Contracts.Collections.DbSettings
{
    public class BlogDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string BlogsCollectionName { get; set; } = null!;
    }
}
