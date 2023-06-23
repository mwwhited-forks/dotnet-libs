﻿using Eliassen.System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Eliassen.TestUtilities
{
    /// <inheritdoc/>
    public class TestContextWrapper : ITestContextWrapper, IResolveType
    {
        /// <inheritdoc/>
        public TestContextWrapper(TestContext context)
        {
            this.Context = context;
        }

        /// <inheritdoc/>
        public TestContext Context { get; }

        private Type? _resolved;
        /// <inheritdoc/>
        public Type ResolveType()
        {
            return _resolved ??= resolveType() ?? throw new InvalidOperationException($"Unable to resolve type class for {Context.FullyQualifiedTestClassName}");

            Type? resolveType()
            {
                var query = from assembly in AppDomain.CurrentDomain.GetAssemblies()
                            from type in assembly.GetTypes()
                            where type.FullName == Context.FullyQualifiedTestClassName
                            select type;
                return query.FirstOrDefault();
            }
        }
    }
}
