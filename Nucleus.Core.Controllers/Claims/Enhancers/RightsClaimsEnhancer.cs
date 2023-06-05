using Eliassen.AspNetCore.Mvc.Filters;
using Newtonsoft.Json.Linq;
using Nucleus.AspNetCore.Mvc.Claims;
using Nucleus.AspNetCore.Mvc.Claims.Enhancers;
using Nucleus.AspNetCore.Mvc.IdentityModel;
using Nucleus.Core.Contracts.Managers;
using Nucleus.Core.Contracts.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Nucleus.Core.Business.Claims.Enhancers
{
    [ClaimsEnhancer(Priority = RightsClaimsEnhancer.Priority)]
    public class RightsClaimsEnhancer : IClaimsEnhancer
    {
        public const int Priority = UserIdClaimsEnhancer.Priority + 1;

        private readonly IUserProfileManager _userProfileManager;

        public RightsClaimsEnhancer(
             IUserProfileManager userProfileManager
            )
        {
            _userProfileManager = userProfileManager;
        }

        public async Task<JObject> EnhanceAsync(JObject claims)
        {
            var userId = (string?)claims[AppClaims.UserId];
            if (!string.IsNullOrEmpty(userId))
            {
                var lookupRights = await _userProfileManager.GetRightsForUserIdAsync(userId);
                claims[ApplicationRightAttribute.Claim] = new JArray(lookupRights.ToArray());
            }
            return claims;
        }
    }
}
