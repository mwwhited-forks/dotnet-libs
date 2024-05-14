using HandlebarsDotNet;
using HandlebarsDotNet.Helpers;
using HandlebarsDotNet.PathStructure;

namespace Eliassen.Handlebars.Helpers;

public abstract class HelperDescriptorBase : IHelperDescriptor<HelperOptions>
{
    protected abstract HandlebarsHelper Helper { get; }
    public abstract PathInfo Name { get; }

    public object Invoke(in HelperOptions options, in Context context, in Arguments arguments) =>
        this.ReturnInvoke(options, context, arguments);

    public void Invoke(in EncodedTextWriter output, in HelperOptions options, in Context context, in Arguments arguments) =>
        Helper(output, context, arguments);
}
