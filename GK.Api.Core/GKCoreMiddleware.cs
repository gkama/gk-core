using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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

        public async Task InvokeAsync(HttpContext http)
        {
            if (!http.Response.HasStarted
                && !string.IsNullOrEmpty(http.TraceIdentifier))
                http.Response.Headers[CoreConstants.RequestIdHttpHeader] = http.TraceIdentifier;

            if (http.Request.Path.StartsWithSegments(AboutPath, out var remaining))
                await WriteAboutInfoAsync(http, remaining);
            else
                await _next(http);

        }

        private async Task WriteAboutInfoAsync(HttpContext http, PathString remaining)
        {
            if (remaining.HasValue)
            {
                if (remaining.Value == "/")
                {
                    http.Response.Redirect(AboutPath, true);
                }
                else
                {
                    http.Response.StatusCode = StatusCodes.Status404NotFound;

                    await http.Response.WriteAsync("Not Found");
                }

                return;
            }

            var about = http.RequestServices.GetRequiredService<AboutInfo>();
            var json = JsonSerializer.Serialize(about, http.RequestServices.GetRequiredService<JsonSerializerOptions>());

            await http.Response.WriteAsync(json);
        }
    }
}
