using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Nucleus.Api.SwaggerGen;

public class ControllerModelConvention : IControllerModelConvention
{
    public void Apply(ControllerModel controller)
    {
        controller.ApiExplorer.GroupName = controller.ControllerType.Assembly.GetName().Name;
    }
}