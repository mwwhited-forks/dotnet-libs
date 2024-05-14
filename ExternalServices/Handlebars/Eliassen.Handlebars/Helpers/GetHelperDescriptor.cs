using HandlebarsDotNet;
using HandlebarsDotNet.PathStructure;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Eliassen.Handlebars.Helpers;

public class GetHelperDescriptor : HelperDescriptorBase
{
    private readonly StateStore _dictionary = new();
    private readonly ILogger _log;

    public GetHelperDescriptor(
        ILogger<SetHelperDescriptor> log
        ) => _log = log;

    public override PathInfo Name => "get";

    protected override HandlebarsHelper Helper => (output, context, arguments) =>
    {
        var key = arguments.ElementAtOrDefault(0)?.ToString();
        _log.LogDebug($"get: {{{nameof(key)}}}", key);
        if (!string.IsNullOrWhiteSpace(key) && _dictionary.TryGetValue(key, out var value))
        {
            output.Write(value);
        }
    };
}
