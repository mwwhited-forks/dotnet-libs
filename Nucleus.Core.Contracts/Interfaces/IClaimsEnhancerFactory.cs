using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleus.Core.Contracts.Interfaces
{
    public interface IClaimsEnhancerFactory
    {
        IEnumerable<IClaimsEnhancer> GetEnhancers();
    }
}
