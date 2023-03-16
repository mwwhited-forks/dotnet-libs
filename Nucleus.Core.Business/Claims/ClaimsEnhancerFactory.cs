using Nucleus.Core.Contracts.Interfaces;
using Nucleus.Core.Contracts.Models;
using Nucleus.Core.Contracts.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleus.Core.Business.Claims
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
