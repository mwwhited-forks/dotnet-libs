using System.Collections.Generic;

namespace Nucleus.Core.Contracts.Models
{
    public class Role : PermissionBase
    {
        public List<PermissionBase>? Rights { get; set; }
    }
}
