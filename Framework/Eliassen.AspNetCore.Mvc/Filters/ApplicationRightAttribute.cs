using Microsoft.AspNetCore.Mvc;

namespace Eliassen.AspNetCore.Mvc.Filters
{
    public class ApplicationRightAttribute : TypeFilterAttribute
    {
        public const string Claim = "app__application_right";
        public string[] Rights { get; }

        public ApplicationRightAttribute(params string[] rights) : 
            base(typeof(ApplicationRightRequirementFilter))
        {
            Rights = rights;
            Arguments = new[] { rights };
        }
    }
}
