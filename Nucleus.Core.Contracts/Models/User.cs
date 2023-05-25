using Eliassen.System.ComponentModel;
using Eliassen.System.Linq;
using System;
using System.Collections.Generic;

namespace Nucleus.Core.Contracts.Models
{
    public class User
    {
        public string? UserId { get; set; }
        public string? UserName { get; set; }

        [DefaultSort(priority: 2, order: OrderDirections.Ascending)]
        public string? EmailAddress { get; set; }

        [DefaultSort(priority: 1, order: OrderDirections.Ascending)]
        public string? FirstName { get; set; }

        [DefaultSort(priority: 0, order: OrderDirections.Ascending)]
        public string? LastName { get; set; }

        public bool Active { get; set; }

        public List<UserModule>? UserModules { get; set; }

        public DateTimeOffset? CreatedOn { get; set; }
    }
}
