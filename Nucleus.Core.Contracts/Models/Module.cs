using System.Collections.Generic;

namespace Nucleus.Core.Contracts.Models
{
    public class Module: PermissionBase
    {
        public string? ModuleId { get; set; }

        public List<Role>? Roles { get; set; }
    }
}
