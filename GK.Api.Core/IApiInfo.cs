using System;

namespace GK.Api.Core
{
    public interface IApiInfo
    {
        string Description { get; set; }
        string FriendlyVersion { get; }
        string FullName { get; }
        string Name { get; set; }
        string SwaggerJsonUrl { get; }
        Version Version { get; set; }
    }
}