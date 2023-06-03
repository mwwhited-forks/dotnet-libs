using Eliassen.System.Security.Claims;
using Nucleus.AspNetCore.Mvc.IdentityModel;
using System.Collections.Generic;
using System.Security.Claims;

namespace Nucleus.Core.Controllers.Security
{
    /// <inheritdoc />
    public class ApplicationUser : IUserSession
    {
        private readonly ClaimsPrincipal _principal;

        /// <inheritdoc />
        public ApplicationUser(
            ClaimsPrincipal principal
            )
        {
            _principal = principal;
        }

        /// <inheritdoc />
        public string? Username => _principal.GetClaimValue(CommonClaims.ObjectIdentifier);

        /// <inheritdoc />
        public string? UserId => _principal.GetClaimValue(CommonClaims.UserId);

        /// <inheritdoc />
        public string? Culture => _principal.GetClaimValue(CommonClaims.Culture);

        /// <inheritdoc />
        public IEnumerable<string> Rights => _principal.GetClaimValues(CommonClaims.ApplicationRight);
    }
}
