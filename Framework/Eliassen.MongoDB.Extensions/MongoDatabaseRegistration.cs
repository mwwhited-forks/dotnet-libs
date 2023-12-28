using System;
using System.Collections.Generic;

namespace Eliassen.MongoDB.Extensions
{
    public class MongoDatabaseRegistration : IMongoDatabaseRegistration
    {
        internal HashSet<Type> InternalTypes = [];
        public IReadOnlyCollection<Type> Types => InternalTypes;
    }
}