using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace GK.Core
{
    /// <summary>
    /// This exception is used to return an error message back to the caller. It should not be used for
    /// exceptions which contain sensitive info such as stack traces, hostnames, etc.
    /// </summary>
    public class GKFriendlyException : GKException
    {
        public GKFriendlyException()
        { }

        public GKFriendlyException(string message)
            : base(message)
        { }

        public GKFriendlyException(HttpStatusCode statusCode, string message)
            : base(statusCode, message)
        { }

        public GKFriendlyException(string message, Exception inner)
            : base(message, inner)
        { }
    }
}
