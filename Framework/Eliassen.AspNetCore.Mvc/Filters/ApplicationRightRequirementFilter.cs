using Eliassen.System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Linq;

namespace Eliassen.AspNetCore.Mvc.Filters
{
    public class ApplicationRightRequirementFilter : IAuthorizationFilter
    {
        public string[] Rights { get; }

        public ApplicationRightRequirementFilter(string[] rights)
        {
            Rights = rights;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            bool? userAuthenticated = context.HttpContext.User.Identity?.IsAuthenticated;
            var userRights = context.HttpContext.User.GetClaimValues(ApplicationRightAttribute.Claim);

            if (userAuthenticated == null || userAuthenticated == false)
                context.Result = new ForbidResult();
            else if (Rights.Any())
                if (!Any(userRights))
                    context.Result = new ForbidResult();
        }

        internal bool Any(IEnumerable<string> items)
        {
            foreach (var item in items)
                if (Rights.Contains(item))
                    return true;
            return false;
        }
    }
}