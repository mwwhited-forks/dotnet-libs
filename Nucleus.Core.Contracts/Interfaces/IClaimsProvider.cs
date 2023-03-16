using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Nucleus.Core.Contracts.Interfaces
{
    public interface IClaimsProvider
    {
        Task<JObject> GetAdditionalClaimsAsync(JObject claims);
    }
}
