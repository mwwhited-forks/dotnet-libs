using Eliassen.System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Logging;
using Nucleus.Core.Contracts.Models;
using System.Security.Authentication;
using System.Linq;
using System.Security.Claims;

namespace Nucleus.AspNetCore.Mvc.Authorization
{
    public class NucleusUserAuthorizationHandler : AuthorizationHandler<NucleusUserAuthorizationRequirement>
    {
        private readonly ILogger _logger;

        public NucleusUserAuthorizationHandler(
            ILogger<NucleusUserAuthorizationHandler> logger
            )
        {
            _logger = logger;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, NucleusUserAuthorizationRequirement requirement)
        {
#if DEBUG
            IdentityModelEventSource.ShowPII = true;
#endif
            var user = context.User;

            var userId = user.GetClaimValue(ApplicationsClaims.UserId);
            if (string.IsNullOrEmpty(userId))
            {
                // This user has not been set yet because we have not assigned their UserId from the DB to the Claim... so lets get crackin
                try
                {
                    // Get the Username which was given to the user from the B2C Claims (ObjectId in B2C User Screen)
                    var userName = user.GetClaimValue(AzB2cClaims.ObjectId, AzB2cClaims.ObjectIdentifier);
                    _logger.LogDebug($"UserName: {{{nameof(userName)}}}", userName);
                    if (!Guid.TryParse(userName, out var userNameGuid))
                    {
                        _logger.LogError($"ERR-401-Invalid authentication Header | UserName Parsed - {{{nameof(userName)}}}", userName);
                        context.Fail();
                        return;
                    }

                    //userId = (string?)result[ApplicationsClaims.UserId];
                    //if (string.IsNullOrEmpty(userId))
                    //{
                    //    // Custom loggin which will be removed after enough data has been collected
                    //    if (result != null && result.HasValues)
                    //        _logger.LogError($"ERR-401-User not found | userName {{{nameof(userName)}}} | result {{{nameof(result)}}}", userName, result.ToString(Newtonsoft.Json.Formatting.None));
                    //    else
                    //        _logger.LogError($"ERR-401-User not found | userName {{{nameof(userName)}}}", userName);
                    //    // ------------------------------------------------------------------------
                    //    throw new AuthenticationException("User not found");
                    //}

                    context.Succeed(requirement);
                }
                catch (AuthenticationException ex)
                {
                    context.Fail();
                    // Custom loggin which will be removed after enough data has been collected
                    _logger.LogError($"ERR-401-innerError: {{{nameof(ex.Message)}}}", ex.Message);
                    return;
                }
                catch (Exception ex)
                {
                    var existingClaims = context?.User?.Claims ?? Enumerable.Empty<Claim>();

                    _logger.LogError($"Authentication Exception: Has Claims \"{{{nameof(existingClaims)}}}\"", string.Join(';', existingClaims.Select(s => s.Type)));
                    _logger.LogDebug($"Authentication Exception: Has Claims \"{{{nameof(existingClaims)}}}\":: {{{nameof(Exception)}}}", string.Join(';', existingClaims.Select(s => s.Type)), ex);

                    context?.Fail();
                    // Custom loggin which will be removed after enough data has been collected
                    _logger.LogError($"ERR-401-outerError: {{{nameof(ex.Message)}}}", ex.Message);
                    return;
                }
            }
        }
    }
}
