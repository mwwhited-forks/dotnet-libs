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

        public SearchQueryMiddleware(
            RequestDelegate next,
            ILogger<SearchQueryMiddleware> log
            )
        {
            _next = next;
            _log = log;
        }

        private enum RequestType
        {
            Query,
            Json,
            Form,
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

        private static RequestType GetRequestType(HttpContext context) => context.Request switch
        {
            HttpRequest request when request.HasFormContentType => RequestType.Form,
            HttpRequest request when request.HasJsonContentType() => RequestType.Json,
            HttpRequest request when request.Method.Equals("POST", StringComparison.InvariantCultureIgnoreCase) => RequestType.Json,
            _ => RequestType.Query,
        };
        private static IBindingSourceMetadata GetBindingType(RequestType requestType) => requestType switch
        {
            RequestType.Form => new FromFormAttribute(),
            RequestType.Json => new FromBodyAttribute(),
            RequestType.Query => new FromQueryAttribute(),
            _ => throw new NotSupportedException($"{nameof(requestType)}: {requestType} is not supported"),
        };

        private static async Task<IValueProvider> GetValueProviderAsync(
            HttpContext context,
            ControllerContext controllerContext,
            RequestType requestType
            ) => requestType switch
            {
                //TODO: dictionary <string, object> does not map for forms and query string
                RequestType.Form => new FormValueProvider(BindingSource.Form, context.Request.Form, null),
                RequestType.Json => await CompositeValueProvider.CreateAsync(controllerContext),
                RequestType.Query => new QueryStringValueProvider(BindingSource.Query, context.Request.Query, null),
                _ => throw new NotSupportedException($"{nameof(requestType)}: {requestType} is not supported"),
            };

        private static async Task<(bool isSearch, T? model)> GetModelAsync<T>(HttpContext context, string modelName = "")
            where T : class
        {
            var descriptor = GetControllerActionDescriptor(context);
            if (descriptor == null) return (false, default);

            if (!descriptor.MethodInfo.ReturnType.IsAssignableTo(typeof(IQueryable))) return (false, default);

            var actionContext = GetActionContext(context, descriptor);
            if (actionContext == null) return (false, default);
            var controllerContext = GetControllerContext(actionContext);
            if (controllerContext == null) return (false, default);

            var modelBinderFactory = context.RequestServices.GetRequiredService<IModelBinderFactory>();

            var requestType = GetRequestType(context);
            var bindingType = GetBindingType(requestType);

            var modelBinderContext = new ModelBinderFactoryContext
            {
                Metadata = new EmptyModelMetadataProvider().GetMetadataForType(typeof(T)),
                BindingInfo = BindingInfo.GetBindingInfo(new[] { bindingType })
            };

            var modelBinder = modelBinderFactory.CreateBinder(modelBinderContext);
            var valueProvider = await GetValueProviderAsync(context, controllerContext, requestType);

            var modelBindingContext = DefaultModelBindingContext.CreateBindingContext(
                actionContext: actionContext,
                valueProvider: valueProvider,
                metadata: modelBinderContext.Metadata,
                bindingInfo: modelBinderContext.BindingInfo,
                modelName: modelName);

            await modelBinder.BindModelAsync(modelBindingContext);

            if (modelBindingContext.Result.IsModelSet &&
                modelBindingContext.Result.Model is T model)
                return (true, model);

            return (true, default);
        }
        public async Task InvokeAsync(HttpContext context, ISearchQueryAccessor accessor)
        {
            try
            {
                var (isSearch, searchModel) = await GetModelAsync<SearchQuery>(context);
                if (isSearch)
                {
                    if (searchModel == null)
                    {
                        _log.LogWarning($"SearchQuery not bound");
                    }
                    else
                    {
                        _log.LogInformation($"Invoking: {{{nameof(searchModel)}}}", searchModel);
                    }
                    accessor.SearchQuery = searchModel;
                }
                await _next(context);
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
