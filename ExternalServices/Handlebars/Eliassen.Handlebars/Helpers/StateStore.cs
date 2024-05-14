using System.Collections.Generic;
using System.Threading;

namespace Eliassen.Handlebars.Helpers;

public class StateStore
{
    private readonly static AsyncLocal<Dictionary<string, object>> _state = new();

    public object this[string key]
    {
        get => _state.Value[key];
        set => _state.Value[key] = value;
    }

    public bool TryAdd(string key, object value) => _state.Value.TryAdd(key, value);
    public bool TryGetValue(string key, out object value) => _state.Value.TryGetValue(key, out value);
}
