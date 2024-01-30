using Eliassen.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Eliassen.WebApi.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class UserController(
    ClaimsPrincipal claimsPrincipal
    )
{

    [HttpGet("claims")]
    public IEnumerable<ClaimModel> GetClaims() =>
         from claim in claimsPrincipal.Claims
         select new ClaimModel
         {
             Issuer = claim.Issuer,
             Value = claim.Value,
             ValueType = claim.ValueType,
             Type = claim.Type,
             OriginalIssuer = claim.OriginalIssuer,
             SubjectName = claim.Subject?.Name,
             SubjectLabel = claim.Subject?.Label,
             SubjectAuthenticationType = claim.Subject?.AuthenticationType,
         };
}
