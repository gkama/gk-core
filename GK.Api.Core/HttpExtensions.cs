using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using JetBrains.Annotations;

namespace GK.Api.Core
{
    public static class HttpExtensions
    {
        /// <summary>
        /// If a <see cref="HttpContext.TraceIdentifier"/> has already been set by the framework, returns it; otherwise generates
        /// a new one then sets and returns it.
        /// </summary>
        public static string GetRequestId([CanBeNull] this HttpContext httpContext)
        {
            if (!string.IsNullOrEmpty(httpContext?.TraceIdentifier))
                return httpContext.TraceIdentifier;

            var id = Guid.NewGuid().ToString();

            if (httpContext != null)
                httpContext.TraceIdentifier = id;

            return id;
        }
    }
}
