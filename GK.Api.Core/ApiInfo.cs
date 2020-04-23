using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GK.Api.Core
{
    /// <summary>
    /// Contains general information about an API.
    /// </summary>
    public class ApiInfo : IApiInfo
    {
        /// <summary>
        /// A human-readable name for the API.
        /// </summary>
        public string Name { get; set; } = "GK API";

        /// <summary>
        /// A human-readable description for the API.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The version of the API.
        /// </summary>
        [JsonIgnore]
        public Version Version { get; set; } = new Version(0, 0, 1, 0);

        /// <summary>
        /// Returns the API version as a string with "v" prefix to use in URLs, docs, etc.
        /// </summary>
        [JsonPropertyName("version")]
        public string FriendlyVersion => "v" + Version.ToString();

        /// <summary>
        /// The name and version of this API.
        /// </summary>
        public string FullName => $"{Name} {FriendlyVersion}";

        /// <summary>
        /// The URL for the Swagger JSON documentation endpoint for this API.
        /// </summary>
        [JsonIgnore]
        public string SwaggerJsonUrl => $"/{CoreConstants.SwaggerRoutePrefix}/{FriendlyVersion}/{CoreConstants.SwaggerJsonEndpoint}";

        internal ApiInfo SetDefaults(BuildInfo buildInfo)
        {
            if (string.IsNullOrEmpty(Name))
                Name = buildInfo.AssemblyName;

            if (string.IsNullOrEmpty(Description))
                Description = buildInfo.AssemblyDescription;

            // TODO determine whether we want to set the API version from the assembly version, and rules for doing so

            return this;
        }
    }
}
