using Microsoft.OpenApi.Interfaces;
using Microsoft.OpenApi.Writers;
using Microsoft.OpenApi;
using System.Collections.Generic;
using System.Linq;

namespace Eliassen.AspNetCore.Mvc.OpenApi;

public class ApiPermissionsExtension : IOpenApiExtension
{
    public ApiPermissionsExtension(bool allowAnonymous, IEnumerable<string> rights)
    {
        AllowAnonymous = allowAnonymous;
        Rights = rights.Distinct().ToList().AsReadOnly();
    }

    public bool AllowAnonymous { get; }
    public IReadOnlyCollection<string> Rights { get; }

    public void Write(IOpenApiWriter writer, OpenApiSpecVersion specVersion)
    {
        writer.WriteStartObject();
        writer.WriteProperty("anonymous", AllowAnonymous);
        writer.WriteOptionalCollection("right", Rights, (w, v) => { w.WriteValue(v); });
        writer.WriteEndObject();
    }
}
