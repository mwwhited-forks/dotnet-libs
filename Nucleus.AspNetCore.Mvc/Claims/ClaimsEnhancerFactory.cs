using Nucleus.AspNetCore.Mvc.IdentityModel;
using System.Collections.Generic;
using System.Linq;
using Eliassen.System.Reflection;

namespace Nucleus.AspNetCore.Mvc.Claims
{
    public class ClaimsEnhancerFactory : IClaimsEnhancerFactory
    {
        private readonly IEnumerable<IClaimsEnhancer> _enhancers;

        public ClaimsEnhancerFactory(
            IEnumerable<IClaimsEnhancer> enhancers
            )
        {
            _enhancers = enhancers;
        }

        public IEnumerable<IClaimsEnhancer> GetEnhancers() =>
           from enhancer in _enhancers
           let priority = enhancer.GetType().GetAttributes<ClaimsEnhancerAttribute>().Min(a => (int?)a.Priority)
           orderby priority ?? 0
           select enhancer;
    }
}
