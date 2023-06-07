using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleus.AspNetCore.Mvc.IdentityModel
{
    public interface IUserSession
    {
        string Username { get; }
        string Culture { get; }
        IEnumerable<string> Rights { get; }
    }
}
