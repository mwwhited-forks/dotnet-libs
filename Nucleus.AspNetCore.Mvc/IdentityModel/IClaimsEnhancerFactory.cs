using Nucleus.AspNetCore.Mvc.IdentityModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleus.AspNetCore.Mvc.IdentityModel
{
    public interface IClaimsEnhancerFactory
    {
        IEnumerable<IClaimsEnhancer> GetEnhancers();
    }
}
