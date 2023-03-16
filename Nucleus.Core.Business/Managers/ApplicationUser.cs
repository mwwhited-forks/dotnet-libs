using Nucleus.Core.Contracts.Interfaces;
using Nucleus.Core.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Nucleus.Core.Contracts.Extensions;
using System.Text;

namespace Nucleus.Core.Business.Managers
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
        
        public string Culture => _principal.GetClaimValue(Contracts.Models.Claims.Culture);

        public IEnumerable<string> Rights => _principal.GetClaimValues(Contracts.Models.Claims.Rights);

    }
}
