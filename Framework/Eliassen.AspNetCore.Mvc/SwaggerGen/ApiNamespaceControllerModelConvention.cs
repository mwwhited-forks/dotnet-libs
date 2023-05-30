using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Eliassen.AspNetCore.Mvc.SwaggerGen;

public class ApiNamespaceControllerModelConvention : IControllerModelConvention
{
    public void Apply(ControllerModel controller)
    {
        controller.ApiExplorer.GroupName = controller.ControllerType.Assembly.GetName().Name;
    }
}
