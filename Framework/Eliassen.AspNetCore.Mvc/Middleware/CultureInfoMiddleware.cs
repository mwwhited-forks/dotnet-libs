using Eliassen.System.Accessors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Eliassen.AspNetCore.Mvc.Middleware
{
    /// <summary>
    /// Custom middleware to enable detection of language/culture from HTTP 
    /// request header as well as assignment for response header
    /// </summary>
    public class CultureInfoMiddleware(
        RequestDelegate next
            )
    {

        public async Task Invoke(
            HttpContext context,
            ILogger<CultureInfoMiddleware> logger,
            IAccessor<CultureInfo> cultureInfo
            )
        {
            try
            {
                // https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Accept-Language
                var fromHeader = (string?)context.Request.Headers.AcceptLanguage;
                if (!string.IsNullOrWhiteSpace(fromHeader))
                {
                    var language = fromHeader.Split(',').Select(GetCultureInfo).FirstOrDefault();
                    logger.LogInformation($"Set CultureInfo to \"{{{nameof(fromHeader)}}}\"::{{{nameof(language)}}}", fromHeader, language);

                    cultureInfo.Value = language ?? CultureInfo.CurrentCulture;
                    CultureInfo.CurrentCulture = CultureInfo.CurrentUICulture = cultureInfo.Value;
                }

                context.Response.OnStarting(cia =>
                {
                    //https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Language
                    var culture = cultureInfo.Value?.ToString();
                    if (!string.IsNullOrWhiteSpace(culture))
                    {
                        logger.LogInformation($"Return CultureInfo as {{{nameof(culture)}}}", culture);
                        context.Response.Headers.ContentLanguage = culture;
                    }

                    return Task.CompletedTask;

                }, cultureInfo);

                await next.Invoke(context);
            }
            catch (Exception ex)
            {
                logger.LogError($"{{{nameof(ex.Message)}}}", ex.Message);
                logger.LogDebug($"{{{nameof(Exception)}}}", ex);
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
