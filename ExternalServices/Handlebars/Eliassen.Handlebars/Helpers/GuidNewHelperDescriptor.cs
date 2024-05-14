using HandlebarsDotNet;
using HandlebarsDotNet.PathStructure;
using System;

namespace Eliassen.Handlebars.Helpers;

public class GuidNewHelperDescriptor : HelperDescriptorBase
{
    public override PathInfo Name => "guid_new";

    protected override HandlebarsHelper Helper => (output, context, arguments) =>
     output.WriteSafeString(Guid.NewGuid());
}
