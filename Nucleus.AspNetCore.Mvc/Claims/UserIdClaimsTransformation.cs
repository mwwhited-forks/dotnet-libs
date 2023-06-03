using Eliassen.System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Nucleus.Core.Contracts.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Nucleus.AspNetCore.Mvc.Claims.Enhancers
{
    public class UserIdClaimsTransformation : IClaimsTransformation
    {
        private readonly IUserClaimsProvider _provider;

        public UserIdClaimsTransformation(
            IUserClaimsProvider provider
            )
        {
            _provider = provider;
        }

        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            var username = principal.GetClaimValue(AzB2cClaims.ObjectId, AzB2cClaims.ObjectIdentifier);
            if (!string.IsNullOrWhiteSpace(username))
            {
                var userId = await _provider.GetUserIdByUserNameAsync(username);

                if (!string.IsNullOrWhiteSpace(userId))
                {
                    principal.AddIdentity(new ClaimsIdentity(principal.Identity, new[] { new Claim(ApplicationsClaims.UserId, userId) }));
                }
            }
            return principal;
        }
    }
}
