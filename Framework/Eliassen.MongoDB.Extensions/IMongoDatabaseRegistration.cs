using System;
using System.Collections.Generic;

namespace Eliassen.MongoDB.Extensions
{
    public interface IMongoDatabaseRegistration
    {
        IReadOnlyCollection<Type> Types { get; }
    }
}