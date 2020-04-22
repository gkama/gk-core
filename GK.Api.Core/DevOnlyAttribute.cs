using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GK.Api.Core
{
    /// <summary>
    /// Indicates that the target method or controller is used only in Development environment.
    /// </summary>
    public class DevOnlyAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var env = context.HttpContext.RequestServices.GetRequiredService<IWebHostEnvironment>();

            if (!env.IsDevelopment())
            {
                context.Result = new NotFoundResult();
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}
