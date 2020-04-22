using System;
using System.Collections.Generic;
using System.Text;

namespace GK.Api.Core
{
    internal static class CoreConstants
    {
        public const string JsonContentType = "application/json";
        public const string RequestIdHttpHeader = "X-RequestId";
        public const string DefaultLoggerCategory = "GK API Logger";

        internal const string AboutPagePrefix = "about";
        internal const string HealthCheckRoutePrefix = "health";
        internal const string SwaggerRoutePrefix = "docs";
        internal const string SwaggerJsonEndpoint = "swagger.json";
    }
}
