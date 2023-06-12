using System.Collections.Generic;

namespace Nucleus.Core.Persistence.Models
{
    public class UserModule : PermissionBase
    {
        public List<Role>? Roles { get; set; }
    }
}
