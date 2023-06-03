using Eliassen.System.Accessors;
using Eliassen.System.Linq.Search;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Eliassen.AspNetCore.Mvc.Middleware
{
    public class SearchQueryMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _log;
        private readonly IAccessor<ISearchQuery> _searchQuery;

        public SearchQueryMiddleware(
            RequestDelegate next,
            ILogger<SearchQueryMiddleware> log,
            IAccessor<ISearchQuery> searchQuery
            )
        {
            _next = next;
            _log = log;
            _searchQuery = searchQuery;
        }

        private static ControllerActionDescriptor? GetControllerActionDescriptor(HttpContext context) =>
            context.GetEndpoint()?.Metadata.OfType<ControllerActionDescriptor>().FirstOrDefault();

        private static ActionContext? GetActionContext(HttpContext context, ControllerActionDescriptor descriptor) =>
             descriptor switch
             {
                 ControllerActionDescriptor => new ActionContext(context, context.GetRouteData(), descriptor),
                 _ => null
             };

        private static ControllerContext? GetControllerContext(ActionContext? context) =>
            context switch
            {
                ActionContext actionContext => new ControllerContext(actionContext),
                _ => null
            };

        private static async Task<T?> GetModelAsync<T>(HttpContext context, string modelName = "")
            where T : class
        {
            var descriptor = GetControllerActionDescriptor(context);
            if (descriptor == null) return null;

            if (!descriptor.MethodInfo.ReturnType.IsAssignableTo(typeof(IQueryable))) return null;

            var actionContext = GetActionContext(context, descriptor);
            if (actionContext == null) return null;
            var controllerContext = GetControllerContext(actionContext);
            if (controllerContext == null) return null;

            var modelBinderFactory = context.RequestServices.GetRequiredService<IModelBinderFactory>();

            IBindingSourceMetadata bindingType = context.Request switch
            {
                HttpRequest request when request.HasFormContentType => new FromFormAttribute(),
                HttpRequest request when request.HasJsonContentType() => new FromBodyAttribute(),
                _ => new FromQueryAttribute(),
            };

            var modelBinderContext = new ModelBinderFactoryContext
            {
                Metadata = new EmptyModelMetadataProvider().GetMetadataForType(typeof(T)),
                BindingInfo = BindingInfo.GetBindingInfo(new[] { bindingType })
            };
            var modelBinder = modelBinderFactory.CreateBinder(modelBinderContext);


            IValueProvider valueProvider = context.Request switch
            {
                HttpRequest request when request.HasFormContentType => new FormValueProvider(BindingSource.Form, context.Request.Form, null),
                HttpRequest request when request.HasJsonContentType() => await CompositeValueProvider.CreateAsync(controllerContext),
                _ => new QueryStringValueProvider(BindingSource.Query, context.Request.Query, null)
            };

            var modelBindingContext = DefaultModelBindingContext.CreateBindingContext(
                actionContext: actionContext,
                valueProvider: valueProvider,
                metadata: modelBinderContext.Metadata,
                bindingInfo: modelBinderContext.BindingInfo,
                modelName: modelName);

            await modelBinder.BindModelAsync(modelBindingContext);

            if (modelBindingContext.Result.IsModelSet &&
                modelBindingContext.Result.Model is T model)
                return model;

            return null;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                var searchModel = await GetModelAsync<SearchQuery>(context);
                if (searchModel != null)
                    _log.LogInformation($"Invoking: {{{nameof(searchModel)}}}", searchModel);
                _searchQuery.Value = searchModel;
                await _next(context);
                if (searchModel != null)
                    _log.LogInformation($"Invoked: {{{nameof(searchModel)}}}", searchModel);
            }
            catch (Exception ex)
            {
                _log.LogInformation("Error");
                _log.LogError($"{{{nameof(ex.Message)}}}", ex.Message);
                throw;
            }
        }
    }
}
