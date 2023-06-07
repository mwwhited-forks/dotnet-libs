using System;
using System.Collections.Generic;

namespace Eliassen.System.Reflection
{
    public interface IEnumModel
    {
        string? Code { get; }
        string? Description { get; }

        int Id { get; }
        bool IsEndState { get; }
        bool IsExcludeFromUnique { get; }
        string? Name { get; }
        int? Order { get; }
        object Value { get; }

        IReadOnlyCollection<string> PossibleNames { get; }
    }
    public interface IEnumModel<TEnum> : IEnumModel where TEnum : struct, Enum
    {
        new TEnum Value { get; }
    }
}
