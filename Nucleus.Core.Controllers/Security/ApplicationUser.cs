using Eliassen.System.Security.Claims;
using Nucleus.AspNetCore.Mvc.IdentityModel;
using System.Collections.Generic;
using System.Linq;
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
        public string? UserName => _principal.GetClaimValue(CommonClaims.ObjectIdentifier)?.value;

        /// <inheritdoc />
        public string? UserId => _principal.GetClaimValue(CommonClaims.UserId)?.value;

        /// <inheritdoc />
        public string? Culture => _principal.GetClaimValue(CommonClaims.Culture)?.value;

        /// <inheritdoc />
        public IEnumerable<string> Rights => _principal.GetClaimValues(CommonClaims.ApplicationRight).Select(c=>c.value);
    }
}
