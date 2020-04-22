using System;

namespace GK.Api.Core
{
    /// <summary>
    /// Represents general information about the results of an operation.
    /// </summary>
    public class ApiMessage
    {
        public string Message { get; set; }

        public ApiMessage() { }
        public ApiMessage(string message) { Message = message; }
    }
}
