using Eliassen.System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Nucleus.Core.Contracts.Managers;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Nucleus.Core.Controllers.Security
{
    /// <inheritdoc />
    public class NucleusClaimsTransformation : IClaimsTransformation
    {
        private readonly IUserProfileManager _manager;

        /// <inheritdoc />
        public NucleusClaimsTransformation(
             IUserProfileManager manager
            )
        {
            _manager = manager;
        }

        /// <inheritdoc />
        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            var claims = new List<Claim>();

            var username = principal.GetClaimValue(CommonClaims.ObjectId, CommonClaims.ObjectIdentifier)?.value;
            var userId = principal.GetClaimValue(CommonClaims.UserId)?.value;
            if (!string.IsNullOrWhiteSpace(username)  && string.IsNullOrWhiteSpace(userId))
            {
                userId = await _manager.GetUserIdForUserNameAsync(username);

                if (!string.IsNullOrWhiteSpace(userId))
                    claims.Add(new Claim(CommonClaims.UserId, userId));
            }

            if (!string.IsNullOrEmpty(userId))
            {
                var rights = await _manager.GetRightsForUserIdAsync(userId);
                foreach (var right in rights)
                    claims.Add(new Claim(CommonClaims.ApplicationRight, right));
            }

            if (claims.Any())
            {
                var identity = new ClaimsIdentity(principal.Identity, claims);
                var newPrincipal = principal.Clone();
                newPrincipal.AddIdentity(identity);
                return newPrincipal;
            }

            return principal;
        }
    }
}
