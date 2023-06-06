using Microsoft.OpenApi.Interfaces;
using Microsoft.OpenApi.Writers;
using Microsoft.OpenApi;
using System.Collections.Generic;
using System.Linq;

namespace Eliassen.AspNetCore.Mvc.OpenApi;

/// <summary>
/// Declare permissions required for application endpoint
/// </summary>
public class ApiPermissionsExtension : IOpenApiExtension
{
    /// <summary>
    /// </summary>
    /// <param name="allowAnonymous">End point allows unauthenticated requests</param>
    /// <param name="rights">end point requires at least one of these permissions</param>
    public ApiPermissionsExtension(bool allowAnonymous, IEnumerable<string> rights)
    {
        AllowAnonymous = allowAnonymous;
        Rights = rights.Distinct().ToList().AsReadOnly();
    }

    /// <summary>
    /// End point allows unauthenticated requests
    /// </summary>
    public bool AllowAnonymous { get; }

    /// <summary>
    /// end point requires at least one of these permissions
    /// </summary>
    public IReadOnlyCollection<string> Rights { get; }

    /// <inheritdoc />
    public void Write(IOpenApiWriter writer, OpenApiSpecVersion specVersion)
    {
        writer.WriteStartObject();
        writer.WriteProperty("anonymous", AllowAnonymous);
        writer.WriteOptionalCollection("right", Rights, (w, v) => { w.WriteValue(v); });
        writer.WriteEndObject();
    }
}
