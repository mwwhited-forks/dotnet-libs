using HandlebarsDotNet;
using HandlebarsDotNet.PathStructure;
using System;
using System.Linq;

namespace Eliassen.Handlebars.Helpers;

public class DateNowHelperDescriptor : HelperDescriptorBase
{
    public override PathInfo Name => "date_now";

    protected override HandlebarsHelper Helper => (output, context, arguments) =>
    {
        var format = arguments.FirstOrDefault() as string;
        if (string.IsNullOrWhiteSpace(format))
            output.WriteSafeString(DateTimeOffset.Now);
        else
            output.WriteSafeString(DateTimeOffset.Now.ToString(format));
    };
}
