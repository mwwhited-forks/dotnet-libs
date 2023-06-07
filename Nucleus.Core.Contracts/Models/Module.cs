using Eliassen.System.ComponentModel.Search;
using System.Collections.Generic;

namespace Nucleus.Core.Contracts.Models
{
    [DefaultSort(targetName: nameof(Name))]
    public class Module : PermissionBase
    {
        public string? ModuleId { get; set; }

        public List<Role>? Roles { get; set; }
    }
}
