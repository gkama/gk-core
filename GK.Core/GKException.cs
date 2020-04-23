using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Text.Json;

namespace GK.Core
{
    public abstract class GKException : ApplicationException
    {
        public int StatusCode { get; set; }
        public string ContentType { get; set; }

        protected GKException()
        { }

        protected GKException(int StatusCode)
        {
            this.StatusCode = StatusCode;
        }

        protected GKException(string Message) : base(Message)
        {
            this.StatusCode = (int)HttpStatusCode.InternalServerError;
        }

        protected GKException(string message, Exception inner) : base(message, inner)
        { }

        protected GKException(int StatusCode, string Message) : base(Message)
        {
            this.StatusCode = StatusCode;
        }

        protected GKException(HttpStatusCode StatusCode, string Message) : base(Message)
        {
            this.StatusCode = (int)StatusCode;
        }

        protected GKException(int StatusCode, Exception Inner) : this(StatusCode, Inner.ToString()) { }
        protected GKException(HttpStatusCode StatusCode, Exception Inner) : this(StatusCode, Inner.ToString()) { }
        protected GKException(int StatusCode, JsonElement ErrorObject) : this(StatusCode, ErrorObject.ToString()) { this.ContentType = @"application/problem+json"; }
    }
}
