using System.Collections.Generic;

namespace Nucleus.AspNetCore.Mvc.IdentityModel
{
    public interface IUserSession
    {
        string? UserName { get; }
        string? UserId { get; }
        string? Culture { get; }
        IEnumerable<string> Rights { get; }
    }
}
