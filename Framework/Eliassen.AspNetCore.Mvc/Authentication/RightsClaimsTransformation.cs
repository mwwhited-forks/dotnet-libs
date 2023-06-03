using Eliassen.System.Linq;
using Eliassen.System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Eliassen.AspNetCore.Mvc.Authentication
{
    public class RightsClaimsTransformation : IClaimsTransformation
    {
        private readonly IEnumerable<IUserClaimsProvider> _rightsProviders;

        public RightsClaimsTransformation(
            IEnumerable<IUserClaimsProvider> rightsProvider
            )
        {
            _rightsProviders = rightsProvider;
        }

        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            var userId = principal.GetClaimValue(ApplicationsClaims.UserId);
            if (!string.IsNullOrEmpty(userId))
            {
                var rightsClaims = await GetClaimRights(userId).AsEnumerableAsync();
                var rightsIdentity = new ClaimsIdentity(principal.Identity, rightsClaims);
                principal.AddIdentity(rightsIdentity);
            }
            return principal;
        }

        private async IAsyncEnumerable<Claim> GetClaimRights(
            string userId,
            [EnumeratorCancellation] CancellationToken cancellationToken = default
            )
        {
            foreach (var provider in _rightsProviders)
                await foreach (var right in provider.GetRightsByUserIdAsync(userId, cancellationToken))
                    yield return new Claim(ApplicationsClaims.ApplicationRight, right);
        }
    }
}
