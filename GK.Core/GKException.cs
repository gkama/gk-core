using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Text.Json;

namespace GK.Core
{
    /// <summary>
    /// Base class for exceptions thrown from GK APIs.
    /// </summary>
    public abstract class GKException : ApplicationException
    {
        public int StatusCode { get; set; }
        public string ContentType { get; set; }

        protected GKException()
        { }

        protected GKException(int statusCode)
        {
            StatusCode = statusCode;
        }

        protected GKException(string message)
            : base(message)
        {
            StatusCode = (int)HttpStatusCode.InternalServerError;
        }

        protected GKException(string message, Exception inner)
            : base(message, inner)
        { }

        protected GKException(int statusCode, string message)
            : base(message)
        {
            StatusCode = statusCode;
        }

        protected GKException(HttpStatusCode statusCode, string message)
            : base(message)
        {
            StatusCode = (int)statusCode;
        }

        protected GKException(int statusCode, Exception inner)
            : this(statusCode, inner.ToString())
        { }

        protected GKException(HttpStatusCode statusCode, Exception inner)
            : this(statusCode, inner.ToString())
        { }

        protected GKException(int statusCode, JsonElement errorObject)
            : this(statusCode, errorObject.ToString())
        {
            ContentType = @"application/problem+json";
        }
    }
}
