using Microsoft.AspNetCore.Mvc;

namespace Eliassen.AspNetCore.Mvc.Filters;

/// <summary>
/// At least one of these declared rights must be assigned to the user to access this point
/// </summary>
public class ApplicationRightAttribute : TypeFilterAttribute
{
    /// <summary>
    /// list of required rights
    /// </summary>
    public string[] Rights { get; }

    /// <summary>
    /// Declare required rights for endpoint
    /// </summary>
    /// <param name="rights"></param>
    public ApplicationRightAttribute(params string[] rights) :
        base(typeof(ApplicationRightRequirementFilter))
    {
        Rights = rights;
        Arguments = new[] { rights };
    }
}
