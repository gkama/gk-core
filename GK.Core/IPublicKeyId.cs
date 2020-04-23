using System;

namespace GK.Core
{
    /// <summary>
    /// An entity which uses an integer id and GUID public key.
    /// </summary>
    public interface IPublicKeyId
    {
        /// <summary>
        /// Used to uniquely identify this entity within a database.
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Used to uniquely identify this entity within its partition.
        /// </summary>
        Guid PublicKey { get; set; }
    }
}
