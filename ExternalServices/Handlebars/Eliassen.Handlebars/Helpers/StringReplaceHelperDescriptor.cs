using HandlebarsDotNet;
using HandlebarsDotNet.PathStructure;
using System.Linq;

namespace Eliassen.Handlebars.Helpers;

public class StringReplaceHelperDescriptor : HelperDescriptorBase
{
    public override PathInfo Name => "str-replace";

    protected override HandlebarsHelper Helper => (output, context, arguments) =>
    {
        var input = arguments.ElementAtOrDefault(0)?.ToString();
        var find = arguments.ElementAtOrDefault(1)?.ToString();
        var replacement = arguments.ElementAtOrDefault(2)?.ToString();
        if (!string.IsNullOrWhiteSpace(input) && !string.IsNullOrWhiteSpace(find))
        {
            output.Write(input.Replace(find, replacement ?? ""));
        }
    };
}
