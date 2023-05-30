using Eliassen.System.Linq;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Eliassen.AspNetCore.Mvc.SwaggerGen;

public class SearchQueryActionModelConvention : IActionModelConvention
{
    public void Apply(ActionModel action)
    {
        //if (action.ActionMethod.ReturnType.IsAssignableTo(typeof(IQueryable)))
        //{
        //    if (!action.Parameters.Any())
        //    {
        //        var element = action.ActionMethod.ReturnType.GetElementType();
        //        var searchType = typeof(SearchQuery<>).MakeGenericType(element);
        //    }

        //    // SearchQuery
        //}
        //else if (action.ActionMethod.ReturnType.IsAssignableTo(typeof(IQueryResult)))
        //{
        //}
    }
}