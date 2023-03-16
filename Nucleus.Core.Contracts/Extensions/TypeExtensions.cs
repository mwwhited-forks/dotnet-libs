using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Nucleus.Core.Contracts.Extensions
{
    public static class TypeExtensions
    {
        public static IEnumerable<TAttribute> GetAttributes<TAttribute>(this Type? type)
            where TAttribute : Attribute =>
            type switch
            {
                null => Enumerable.Empty<TAttribute>(),
                _ => TypeDescriptor.GetAttributes(type).OfType<TAttribute>()
            };
    }
}
