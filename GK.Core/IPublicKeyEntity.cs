using System;
using System.Collections.Generic;
using System.Text;

namespace GK.Core
{
    public interface IPublicKeyEntity
    {
        /// <summary>
        /// Used to uniquely identify this entity within its partition.
        /// </summary>
        Guid PublicKey { get; set; }

        /// <summary>
        /// Used by clients to uniquely identify an entity.
        /// </summary>
        Guid ClientGuid { get; set; }

        /// <summary>
        /// A GUID representing the workspace to which this entity belongs.
        /// </summary>
        Guid WorkspaceGuid { get; set; }
    }
}
