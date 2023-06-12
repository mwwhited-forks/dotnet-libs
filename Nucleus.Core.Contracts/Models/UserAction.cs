using Nucleus.Core.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleus.Core.Persistence.Models
{
    public class UserAction: User
    {
        public string IdentityAction { get; set; }
    }
}
