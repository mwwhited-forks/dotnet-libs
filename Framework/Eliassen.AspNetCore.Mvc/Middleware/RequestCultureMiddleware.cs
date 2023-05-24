using Eliassen.System.Accessors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Eliassen.AspNetCore.Mvc.Middleware
{
    public class CultureInfoMiddleware
    {
        private readonly RequestDelegate _next;
        public CultureInfoMiddleware(
            RequestDelegate next
            )
        {
            _next = next;
        }

        public async Task Invoke(
            HttpContext context,
            ILogger<CultureInfoMiddleware> logger,
            ICultureInfoAccessor accessor
            )
        {
            try
            {
                // https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Accept-Language
                var fromheader = (string)context.Request.Headers["Accept-Language"];
                if (!string.IsNullOrWhiteSpace(fromheader))
                {
                    var language = fromheader.Split(',').Select(GetCultureInfo).FirstOrDefault();
                    logger.LogInformation($"Set CultureInfo to \"{fromheader}\"::{language}");
                    accessor.CultureInfo = language ?? CultureInfo.CurrentCulture;
                    CultureInfo.CurrentCulture = CultureInfo.CurrentUICulture = accessor.CultureInfo;
                }

                context.Response.OnStarting(cia =>
                {
                    //https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Language
                    var culture = accessor.CultureInfo?.ToString();
                    if (!string.IsNullOrWhiteSpace(culture))
                    {
                        logger.LogInformation($"Return CultureInfo as {culture}");
                        context.Response.Headers["Content-Language"] = culture;
                    }

                    return Task.CompletedTask;

                }, accessor);

                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                logger.LogDebug(ex.ToString());
                throw;
            }
        }

        private CultureInfo? GetCultureInfo(string cultureInfo)
        {
            try
            {
                var culture = cultureInfo.Split(';').FirstOrDefault();
                if (culture == null) return null;
                return CultureInfo.GetCultureInfo(culture);
            }
            catch (CultureNotFoundException)
            {
                return default;
            }
        }
    }
}
