using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace GK.Api.Core
{
    public abstract class GKApiStartup
    {
        public readonly IConfiguration _configuration;
        public readonly IWebHostEnvironment _env;
        public readonly ILogger _logger;

        public GKApiStartup(IConfiguration configuration, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _env = env ?? throw new ArgumentNullException(nameof(env));
            _logger = loggerFactory?.CreateLogger("Startup");
        }
    }
}
