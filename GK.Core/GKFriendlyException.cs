using System;
using System.Collections.Generic;
using System.Text;

namespace GK.Core
{
    public class GKFriendlyException : GKException
    {
        public GKFriendlyException()
        { }

        public GKFriendlyException(string message) : base(message)
        { }

        public GKFriendlyException(string message, Exception inner) : base(message, inner)
        { }
    }
}
