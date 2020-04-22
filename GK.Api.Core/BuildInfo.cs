using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GK.Api.Core
{
    /// <summary>
    /// Contains information about the assembly hosting a .NET Core Web API.
    /// </summary>
    public class BuildInfo
    {
        public string AssemblyName { get; set; }
        public string AssemblyDescription { get; set; }
        public string AssemblyVersion { get; set; }
        public static BuildInfo FromType(Type type) => FromAssembly(type.Assembly);

        public static BuildInfo FromAssembly(Assembly assembly)
        {
            var name = assembly?.GetName();

            if (name == null)
                return new BuildInfo();

            return new BuildInfo
            {
                AssemblyName = assembly.GetName().Name,
                AssemblyDescription = assembly.GetCustomAttribute<AssemblyDescriptionAttribute>()?.Description,
                AssemblyVersion = assembly.GetCustomAttribute<AssemblyFileVersionAttribute>()?.Version,
            };
        }
    }
}
