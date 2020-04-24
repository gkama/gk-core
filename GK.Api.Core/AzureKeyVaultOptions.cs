using System;
using System.Collections.Generic;
using System.Text;

namespace GK.Api.Core
{
    /// <summary>
    /// Options for reading secrets from Azure Key Vault.
    /// </summary>
    public class AzureKeyVaultOptions
    {
        /// <summary>
        /// The URL of the Azure Key Vault.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// A unique key which identifies the application connecting to the Key Vault.
        /// </summary>
        public string ApplicationId { get; set; }

        /// <summary>
        /// The Client Secret / Password used to connect to the Azure Key Vault.
        /// </summary>
        public string Secret { get; set; }

        public override string ToString() => $"{Url}; {ApplicationId}";
    }
}
