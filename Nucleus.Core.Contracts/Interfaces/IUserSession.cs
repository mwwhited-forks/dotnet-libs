using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleus.Core.Contracts.Interfaces
{
    public interface IUserSession
    {
        string Username { get; }
        string Culture { get; }
        IEnumerable<string> Rights { get; }
    }
}
