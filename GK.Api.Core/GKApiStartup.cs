using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

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

        public virtual void ConfigureServices(IServiceCollection services)
        {
            AddGKServices(services);
        }

        /// <summary>
        /// Adds common services used by APIs.
        /// </summary>
        private void AddGKServices(IServiceCollection services)
        {
            services.AddSingleton(x =>
            {
                return new ApiInfo()
                    .SetDefaults(BuildInfo.FromType(this.GetType()));
            });

            services.AddHealthChecks();
            services.AddLogging();

            services.AddControllers();
            services.AddMvcCore()
                .AddJsonOptions(o =>
                {
                    o.JsonSerializerOptions.WriteIndented = true;
                    o.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                });
        }
    }
}
