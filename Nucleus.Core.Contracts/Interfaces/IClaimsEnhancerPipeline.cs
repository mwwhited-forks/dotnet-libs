using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nucleus.Core.Contracts.Interfaces
{
    public interface IClaimsEnhancerPipeline
    {
        Task<JObject> EnhanceAsync(JObject claims);
    }
}
