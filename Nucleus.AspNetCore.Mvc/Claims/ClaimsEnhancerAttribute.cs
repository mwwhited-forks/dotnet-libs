using System;

namespace Nucleus.AspNetCore.Mvc.Claims
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class ClaimsEnhancerAttribute : Attribute
    {
        public int Priority { get; set; }
    }
}
