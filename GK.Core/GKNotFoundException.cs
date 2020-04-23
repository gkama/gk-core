using System;
using System.Collections.Generic;
using System.Text;

namespace GK.Core
{
    /// <summary>
    /// This exception is used when a requested item is not found.
    /// </summary>
    public class GKNotFoundException : GKFriendlyException
    {
        private const string DefaultMessage = "The requested item was not found.";

        public GKNotFoundException()
            : base(DefaultMessage)
        { }

        public GKNotFoundException(string message)
            : base(message)
        { }

        public GKNotFoundException(string message, Exception inner)
            : base(message, inner)
        { }

        public GKNotFoundException(Exception inner)
            : base(DefaultMessage, inner)
        { }
    }
}
