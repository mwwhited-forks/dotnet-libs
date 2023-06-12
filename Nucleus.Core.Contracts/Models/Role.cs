using System.Collections.Generic;

namespace Nucleus.Core.Persistence.Models
{
    public class Role : PermissionBase
    {
        public List<PermissionBase>? Rights { get; set; }
    }
}
