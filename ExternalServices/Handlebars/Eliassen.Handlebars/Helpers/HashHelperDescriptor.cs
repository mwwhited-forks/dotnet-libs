using Eliassen.System.Security.Cryptography;
using HandlebarsDotNet;
using HandlebarsDotNet.PathStructure;

namespace Eliassen.Handlebars.Helpers;

public class HashHelperDescriptor : HelperDescriptorBase
{
    private readonly IHash _hash;

    public HashHelperDescriptor(
        IHash hash
        )
    {
        _hash = hash;
    }

    public override PathInfo Name => "hash";

    protected override HandlebarsHelper Helper => (output, context, arguments) =>
    {
        var arg = arguments[0];
        var result = _hash.GetHash(arg?.ToString() ?? "");
        output.WriteSafeString(result);
    };
}
