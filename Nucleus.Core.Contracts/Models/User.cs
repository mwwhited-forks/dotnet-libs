using Nucleus.Core.Contracts.Interfaces;
using System;
using System.Collections.Generic;

namespace Nucleus.Core.Contracts.Models
{
    public class User
    {
        public string? UserId { get; set; }

        public string? UserName { get; set; }

        public string? EmailAddress { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public bool Active { get; set; }

        public List<UserModule>? UserModules { get; set; }

        public DateTimeOffset? CreatedOn { get; set; }
    }
}
