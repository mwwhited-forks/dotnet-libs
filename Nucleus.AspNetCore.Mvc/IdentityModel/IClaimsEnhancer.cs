using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nucleus.AspNetCore.Mvc.IdentityModel
{
    public interface IClaimsEnhancer
    {
        Task<JObject> EnhanceAsync(JObject claims);
    }
}
