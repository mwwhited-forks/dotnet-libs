using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using Nucleus.AspNetCore.Mvc.IdentityModel;
using Nucleus.Core.Contracts.Managers;
using Nucleus.Core.Contracts.Models;
using System;
using System.Threading.Tasks;

namespace Nucleus.AspNetCore.Mvc.Claims.Enhancers
{
    [ClaimsEnhancer(Priority = Priority)]
    public class UserIdClaimsEnhancer : IClaimsEnhancer
    {
        public const int Priority = -1;
        private readonly IUserProfileManager _userProfileManager;
        private readonly ILogger<UserIdClaimsEnhancer> _log;

        public UserIdClaimsEnhancer(
            IUserProfileManager userProfileManager,
            ILogger<UserIdClaimsEnhancer> log
            )
        {
            _userProfileManager = userProfileManager;
            _log = log;
        }

        public async Task<JObject> EnhanceAsync(JObject claims)
        {
            claims[AppClaims.UserId] = await LookupUserIdAsync(claims);
            return claims;
        }

        private async Task<string> LookupUserIdAsync(JObject claims)
        {
            var userName = (string)claims[AzB2cClaims.ObjectId];

            _log.LogInformation($@"Look up user for {{{nameof(AzB2cClaims.ObjectId)}}}:""{{{nameof(userName)}}}""", AzB2cClaims.ObjectId, userName);

            var userid = await _userProfileManager.GetUserIdForUserNameAsync(userName: userName);
            if (string.IsNullOrEmpty(userid))
            {
                _log.LogError($@"No user found for {{{nameof(AzB2cClaims.ObjectId)}}}:""{{{nameof(userName)}}}""", AzB2cClaims.ObjectId, userName);
                // Custom loggin which will be removed after enough data has been collected
                if (claims != null && claims.HasValues)
                    _log.LogError($"ERR-401-No user found for | userName {{{nameof(userName)}}} | {{{nameof(claims)}}}", userName, claims.ToString(Newtonsoft.Json.Formatting.None));
                else
                    _log.LogError($"ERR-401-No user found for | userName {{{nameof(userName)}}}", userName);
                // ------------------------------------------------------------------------
                throw new ApplicationException("Invalid User Requested");
            }

            return userid;
        }
    }
}
