using System;
using System.Text;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

using GK.Core;

namespace GK.Api.Core
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeXApiAttribute : TypeFilterAttribute
    {
        public AuthorizeXApiAttribute()
            : base(typeof(AuthorizeXApiFilter))
        {
        }
    }

    public class AuthorizeXApiFilter : IAuthorizationFilter
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;

        public AuthorizeXApiFilter(IWebHostEnvironment env, IConfiguration configuration)
        {
            _env = env ?? throw new GKFriendlyException(HttpStatusCode.InternalServerError, nameof(env));
            _configuration = configuration ?? throw new GKFriendlyException(HttpStatusCode.InternalServerError, nameof(configuration));
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (_env.IsDevelopment())
                return;

            string xApiKey = context.HttpContext.Request.Headers["x-api-key"];

            if (xApiKey != null)
            {
                if (xApiKey == _configuration["XApiKey"]
                    || xApiKey == _configuration.GetSection(ConfigSections.Configuration)["XApiKey"])
                    return;
            }

            context.HttpContext.Response.Headers["WWW-Authenticate"] = "x-api-key";
            context.Result = new UnauthorizedResult();
        }
    }
}
