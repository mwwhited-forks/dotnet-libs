using System;
using System.Collections.Generic;

namespace Eliassen.MongoDB.Extensions
{
    public class MongoDatabaseRegistation : IMongoDatabaseRegistation
    {
        internal HashSet<Type> InternalTypes = new();
        public IReadOnlyCollection<Type> Types => InternalTypes;
    }
}