using Microsoft.AspNetCore.Mvc;

namespace Nucleus.Core.Busines.Attributes
{
    public class ApplicationRightAttribute : TypeFilterAttribute
    {
        public string[] Rights { get; }

        public ApplicationRightAttribute(params string[] rights) : base(typeof(ApplicationRightRequirementFilter))
        {
            Rights = rights;

            this.Arguments = new[] { rights };
        }
    }
}
