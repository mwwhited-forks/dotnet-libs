using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Eliassen.AspNetCore.Mvc.SwaggerGen;

/// <summary>
/// SwaggerGen extension to configure controller group as the related assembly name
/// </summary>
public class ApiNamespaceControllerModelConvention : IControllerModelConvention
{
    public void Apply(ControllerModel controller)
    {
        controller.ApiExplorer.GroupName = controller.ControllerType.Assembly.GetName().Name;
    }
}
