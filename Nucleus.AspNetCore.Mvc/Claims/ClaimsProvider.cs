using Newtonsoft.Json.Linq;
using Nucleus.AspNetCore.Mvc.IdentityModel;
using System.Threading.Tasks;

namespace Nucleus.AspNetCore.Mvc.Claims
{
    public class ClaimsProvider : IClaimsProvider
    {
        private readonly IClaimsEnhancerPipeline _claims;

        public ClaimsProvider(
             IClaimsEnhancerPipeline claims
            )
        {
            _claims = claims;
        }

        public async Task<JObject> GetAdditionalClaimsAsync(JObject claims) => await _claims.EnhanceAsync(claims);
    }
}
