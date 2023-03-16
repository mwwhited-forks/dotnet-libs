using Nucleus.Core.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleus.Core.Contracts.Models
{
    public class UserAction: User
    {
        public string IdentityAction { get; set; }
    }
}
