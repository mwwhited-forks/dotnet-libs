using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Nucleus.Core.Contracts.Extensions;
using Nucleus.Core.Contracts.Models;
using System.Collections.Generic;
using System.Linq;

namespace Nucleus.Core.Busines.Attributes
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
            var userRigths = context.HttpContext.User.GetClaimValues(Claims.Rights);

            if (userAuthenticated == null || userAuthenticated == false)
                context.Result = new ForbidResult();
            else if (Rights.Any())
                if (!Any(userRigths))
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