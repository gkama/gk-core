using System;

namespace GK.Core
{
    /// <summary>
    /// An entity which uses an integer id and GUID public key.
    /// </summary>
    public interface IPublicKeyId
    {
        int Id { get; set; }
        Guid PublicKey { get; set; }
    }
}
