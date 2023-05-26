using Eliassen.AspNetCore.Mvc.Filters;
using Eliassen.System.Security.Claims;
using Nucleus.AspNetCore.Mvc.IdentityModel;
using Nucleus.Core.Contracts.Models;
using System.Security.Claims;

namespace Nucleus.Core.Controllers.Security
{
    public class ApplicationUser : IUserSession
    {
        private readonly ClaimsPrincipal _principal;

        public ApplicationUser(
            ClaimsPrincipal principal
            )
        {
            _principal = principal;
        }

        public string Username => _principal.GetClaimValue(AzB2cClaims.ObjectIdentifier);

        public string Culture => _principal.GetClaimValue(AppClaims.Culture);

        public IEnumerable<string> Rights => _principal.GetClaimValues(ApplicationRightAttribute.Claim);

    }
}
