using HandlebarsDotNet;
using HandlebarsDotNet.PathStructure;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Eliassen.Handlebars.Helpers;

public class SetHelperDescriptor : HelperDescriptorBase
{
    private readonly StateStore _dictionary = new();
    private readonly ILogger _log;

    public SetHelperDescriptor(
        ILogger<SetHelperDescriptor> log
        ) => _log = log;

    public override PathInfo Name => "set";

    protected override HandlebarsHelper Helper => (output, context, arguments) =>
    {
        var key = arguments.ElementAtOrDefault(0)?.ToString();
        var value = arguments.ElementAtOrDefault(1);
        _log.LogDebug($"set: {{{nameof(key)}}}", key);
        if (!string.IsNullOrWhiteSpace(key) && !_dictionary.TryAdd(key, value ?? ""))
        {
            _dictionary[key] = value ?? "";
        }
    };
}
