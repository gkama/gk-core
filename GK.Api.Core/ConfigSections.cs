using System;
using System.Collections.Generic;
using System.Text;

namespace GK.Api.Core
{
    /// <summary>
    /// Standard config section names for common settings.
    /// </summary>
    public static class ConfigSections
    {
        public const string ConnectionStrings = nameof(ConnectionStrings);
        public const string SQLServer = nameof(SQLServer);
        public const string MySQL = nameof(MySQL);
        public const string PostgreSQL = nameof(PostgreSQL);
        public const string CosmosDB = nameof(CosmosDB);

        public const string KeyVault = nameof(KeyVault);

        public const string Redis = nameof(Redis);

        public const string FeatureFlags = nameof(FeatureFlags);
    }
}
