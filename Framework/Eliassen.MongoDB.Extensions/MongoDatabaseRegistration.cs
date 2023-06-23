using System;
using System.Collections.Generic;

namespace Eliassen.MongoDB.Extensions
{
    /// <inheritdoc/>
    public class MongoDatabaseRegistration : IMongoDatabaseRegistration
    {
        internal HashSet<Type> InternalTypes = new();
        /// <inheritdoc/>
        public IReadOnlyCollection<Type> Types => InternalTypes;
    }
}