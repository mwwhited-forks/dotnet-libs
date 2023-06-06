using Eliassen.System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Linq;

namespace Eliassen.AspNetCore.Mvc.Filters
{
    /// <summary>
    /// Authorization filter to compared application rights for user to rights required by endpoint
    /// </summary>
    public class ApplicationRightRequirementFilter : IAuthorizationFilter
    {
        private readonly IReadOnlyList<string> _rights;

        /// <inheritdoc/>
        public ApplicationRightRequirementFilter(string[] rights)
        {
            _rights = rights;
        }

        /// <inheritdoc/>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            bool? userAuthenticated = context.HttpContext.User.Identity?.IsAuthenticated;
            var userRights = context.HttpContext.User.GetClaimValues(CommonClaims.ApplicationRight);

            if (userAuthenticated == null || userAuthenticated == false)
                context.Result = new ForbidResult();
            else if (_rights.Any())
                if (!Any(userRights))
                    context.Result = new ForbidResult();
        }

        internal bool Any(IEnumerable<string> items)
        {
            foreach (var item in items)
                if (_rights.Contains(item))
                    return true;
            return false;
        }
    }
}