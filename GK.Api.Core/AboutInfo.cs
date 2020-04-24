using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.AspNetCore.Hosting;

namespace GK.Api.Core
{
    public class AboutInfo
    {
        public ApiInfo Api { get; set; }
        public BuildInfo Build { get; set; }
        public HostingInfo Hosting { get; set; } = new HostingInfo();

        public object Config { get; set; }

        public AboutInfo SetHostingInfo(IWebHostEnvironment env)
        {
            Hosting.Environment = env.EnvironmentName;
            Hosting.AppName = env.ApplicationName;
            Hosting.ContentRoot = env.ContentRootPath;
            Hosting.WebRoot = env.WebRootPath;

            return this;
        }

        public class HostingInfo
        {
            public string Environment { get; set; }
            public string AppName { get; set; }
            public string ContentRoot { get; set; }
            public string WebRoot { get; set; }
        }
    }
}
