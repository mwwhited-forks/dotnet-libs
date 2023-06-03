using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Eliassen.System.Security.Claims
{
    public interface IUserClaimsProvider
    {
        IAsyncEnumerable<string> GetRightsByUserIdAsync(string userId, [EnumeratorCancellation] CancellationToken cancellationToken = default);
        Task<string?> GetUserIdByUserNameAsync(string userName);
    }
}
