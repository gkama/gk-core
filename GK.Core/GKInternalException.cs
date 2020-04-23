using System;
using System.Collections.Generic;
using System.Text;

namespace GK.Core
{
    /// <summary>
    /// This exception is used to capture internal errors which should not be displayed/returned to the caller.
    /// A general error message will be returned instead.
    /// </summary>
    public class GKInternalException : GKException
    {
        public GKInternalException()
        { }

        public GKInternalException(string message) : base(message)
        { }

        public GKInternalException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
