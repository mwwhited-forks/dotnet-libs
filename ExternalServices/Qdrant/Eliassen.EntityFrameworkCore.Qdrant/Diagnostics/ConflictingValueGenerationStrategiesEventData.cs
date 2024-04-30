using Eliassen.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata;
using System;

namespace Eliassen.EntityFrameworkCore.Diagnostics;

public class ConflictingValueGenerationStrategiesEventData : EventData
{
    public ConflictingValueGenerationStrategiesEventData(
        EventDefinitionBase eventDefinition,
        Func<EventDefinitionBase, EventData, string> messageGenerator,
        QdrantValueGenerationStrategy QdrantValueGenerationStrategy,
        string otherValueGenerationStrategy,
        IReadOnlyProperty property)
        : base(eventDefinition, messageGenerator)
    {
        QdrantValueGenerationStrategy = QdrantValueGenerationStrategy;
        OtherValueGenerationStrategy = otherValueGenerationStrategy;
        Property = property;
    }

    public virtual QdrantValueGenerationStrategy QdrantValueGenerationStrategy { get; }

    public virtual string OtherValueGenerationStrategy { get; }

    public virtual IReadOnlyProperty Property { get; }
}
