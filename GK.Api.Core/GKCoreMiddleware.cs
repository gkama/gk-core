using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace GK.Api.Core
{
    /// <summary>
    /// Sets up common request / response handling for all APIs.
    /// </summary>
    public class GKCoreMiddleware
    {
        private const string AboutPath = "/" + CoreConstants.AboutPagePrefix;
        private readonly RequestDelegate _next;

        public GKCoreMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            if (!httpContext.Response.HasStarted
                && !string.IsNullOrEmpty(httpContext.TraceIdentifier))
                httpContext.Response.Headers[CoreConstants.RequestIdHttpHeader] = httpContext.TraceIdentifier;

            if (httpContext.Request.Path.StartsWithSegments(AboutPath, out var remaining))
                await WriteAboutInfoAsync(httpContext, remaining);
            else
                await _next(httpContext);

        }

        private async Task WriteAboutInfoAsync(HttpContext httpContext, PathString remaining)
        {
            if (remaining.HasValue)
            {
                if (remaining.Value == "/")
                {
                    httpContext.Response.Redirect(AboutPath, true);
                }
                else
                {
                    httpContext.Response.StatusCode = StatusCodes.Status404NotFound;

                    await httpContext.Response.WriteAsync("Not Found");
                }

                return;
            }

            var about = httpContext.RequestServices.GetRequiredService<AboutInfo>();
            var json = JsonSerializer.Serialize(about, httpContext.RequestServices.GetRequiredService<JsonSerializerOptions>());

            await httpContext.Response.WriteAsync(json);
        }
    }

    public static partial class HttpStatusCodeExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseGKCoreMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GKCoreMiddleware>();
        }
    }
}
