using System;
using System.Collections.Generic;

namespace Eliassen.MongoDB.Extensions
{
    public interface IMongoDatabaseRegistation
    {
        IReadOnlyCollection<Type> Types { get; }
    }
}