using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleus.Core.Contracts.Models.DbSettings
{
    public class ModuleDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string ModuleCollectionName { get; set; } = null!;
    }
}
