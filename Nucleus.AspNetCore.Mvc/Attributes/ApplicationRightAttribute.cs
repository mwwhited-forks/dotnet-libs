using Microsoft.AspNetCore.Mvc;

namespace Nucleus.AspNetCore.Mvc.Attributes
{
    public class ApplicationRightAttribute : TypeFilterAttribute
    {
        public string[] Rights { get; }

        public ApplicationRightAttribute(params string[] rights) : base(typeof(ApplicationRightRequirementFilter))
        {
            Rights = rights;

            Arguments = new[] { rights };
        }
    }
}
