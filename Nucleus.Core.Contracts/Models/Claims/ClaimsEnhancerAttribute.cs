using System;

namespace Nucleus.Core.Contracts.Models
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class ClaimsEnhancerAttribute : Attribute
    {
        public int Priority { get; set; }
    }
}
