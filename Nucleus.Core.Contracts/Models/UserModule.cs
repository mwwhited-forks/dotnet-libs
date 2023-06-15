using System.Collections.Generic;

namespace Nucleus.Core.Contracts.Models
{
    public class UserModule : PermissionBase
    {
        public List<Role>? Roles { get; set; }
    }
}
