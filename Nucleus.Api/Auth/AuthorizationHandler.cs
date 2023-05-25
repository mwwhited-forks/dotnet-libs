using Eliassen.System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Logging;
using Newtonsoft.Json.Linq;
using Nucleus.AspNetCore.Mvc.IdentityModel;
using Nucleus.Core.Contracts.Models;
using System.Security.Authentication;
using System.Security.Claims;
using static Nucleus.Core.Contracts.Rights;

namespace Nucleus.Api.Auth
{
    public class AuthorizationHandler : AuthorizationHandler<UserAuthorizationRequirement>
    {
        private readonly ILogger<AuthorizationHandler> _logger;
        private readonly IClaimsProvider _claims;

        public AuthorizationHandler(ILogger<AuthorizationHandler> logger, IClaimsProvider claims)
        {
            _logger = logger;
            _claims = claims;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, UserAuthorizationRequirement requirement)
        {
#if DEBUG
            IdentityModelEventSource.ShowPII = true;
#endif
            var user = context.User;

            var userId = user.GetClaimValue(AppClaims.UserId);
            if (String.IsNullOrEmpty(userId))
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

                    var data = new JObject
                    {
                        [AzB2cClaims.ObjectId] = userName
                    };

                    // Initiating the process to get additional claims from our Claims Enhancers (Core->Business->Claims->Enhancers)
                    var result = await _claims.GetAdditionalClaimsAsync(data).ConfigureAwait(false);

                    userId = (string?)result[AppClaims.UserId];
                    if (String.IsNullOrEmpty(userId))
                    {
                        // Custom loggin which will be removed after enough data has been collected
                        if (result != null && result.HasValues)
                            _logger.LogError($"ERR-401-User not found | userName {{{nameof(userName)}}} | result {{{nameof(result)}}}", userName, result.ToString(Newtonsoft.Json.Formatting.None));
                        else
                            _logger.LogError($"ERR-401-User not found | userName {{{nameof(userName)}}}", userName);
                        // ------------------------------------------------------------------------
                        throw new AuthenticationException("User not found");
                    }

                    var newClaims = from p in result.Properties()
                                    let vs = p.Value is JArray arr ? arr.Values<string>() : new[] { (string)p.Value }
                                    from v in vs
                                    select new Claim(p.Name, v);
                    user.AddIdentity(new ClaimsIdentity(user.Identity, newClaims));

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
