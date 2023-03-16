using Nucleus.Core.Contracts.Interfaces;
using Nucleus.Core.Contracts.Managers;
using Nucleus.Core.Contracts.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nucleus.Core.Business.Claims.Enhancers
{
    [ClaimsEnhancer(Priority = UserIdClaimsEnhancer.Priority)]
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
            claims[Contracts.Models.Claims.UserId] = await LookupUserIdAsync(claims);
            return claims;
        }

        private async Task<string> LookupUserIdAsync(JObject claims)
        {
            var userName = (string)claims[AzB2cClaims.ObjectId];

            _log.LogInformation($@"Look up user for {AzB2cClaims.ObjectId}:""{userName}""");

            var userid = await _userProfileManager.GetUserIdForUserNameAsync(userName: userName);
            if (String.IsNullOrEmpty(userid))
            {
                _log.LogError($@"No user found for {AzB2cClaims.ObjectId}:""{userName}""");
                // Custom loggin which will be removed after enough data has been collected
                if (claims != null && claims.HasValues)
                    _log.LogError("ERR-401-No user found for | userName " + userName + " | result " + claims.ToString(Newtonsoft.Json.Formatting.None));
                else
                    _log.LogError("ERR-401-No user found for | userName " + userName);
                // ------------------------------------------------------------------------
                throw new ApplicationException("Invalid User Requested");
            }

            return userid;
        }
    }
}
