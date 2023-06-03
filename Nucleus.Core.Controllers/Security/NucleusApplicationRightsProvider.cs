using Eliassen.System.Linq;
using Eliassen.System.Security.Claims;
using Nucleus.Core.Contracts.Managers;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Nucleus.Core.Controllers.Security
{
    public class NucleusApplicationRightsProvider : IUserClaimsProvider
    {
        private readonly IUserProfileManager _manager;

        public NucleusApplicationRightsProvider(
             IUserProfileManager manager
            )
        {
            _manager = manager;
        }

        public IAsyncEnumerable<string> GetRightsByUserIdAsync(
            string userId,
            [EnumeratorCancellation] CancellationToken cancellationToken = default
            ) => _manager.GetRightsForUserIdAsync(userId)
                         .AsAsyncEnumerable(cancellationToken);

        public async Task<string?> GetUserIdByUserNameAsync(string userName) =>
            await _manager.GetUserIdForUserNameAsync(userName);
    }
}
