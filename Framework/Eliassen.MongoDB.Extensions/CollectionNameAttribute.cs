﻿using System;

namespace Eliassen.MongoDB.Extensions;

/// <summary>
/// declarative attribute for labeling properties as MongoDB Collections
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, AllowMultiple = false)]
public class CollectionNameAttribute(
    string collectionName) : Attribute
{
    /// <summary>
    /// Name to use for MongoDB collection
    /// </summary>
    public string CollectionName { get; } = collectionName;

    /// <summary>
    /// Gets the type identifier for the attribute.
    /// </summary>
    public override object TypeId => this;
}