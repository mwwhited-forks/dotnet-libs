using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Linq;

namespace Eliassen.AspNetCore.Mvc.Filters
{
    public class TypeSchemaFilter : ISchemaFilter
    {

        public string ResolveTitle(Type type)
        {
            if (type.IsGenericType)
            {
                return $"{type.Namespace}.{type.Name.Split('`')[0]}[{string.Join(",", type.GetGenericArguments().Select(ResolveTitle))}]";
            }

            return type.FullName;
        }


        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type.IsGenericType)
            {
                schema.Title = ResolveTitle(context.Type);
            }
        }
    }
}
