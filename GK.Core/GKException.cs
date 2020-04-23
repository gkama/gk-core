using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Text.Json;

namespace GK.Core
{
    public class GKException : ApplicationException
    {
        public int StatusCode { get; set; }
        public string ContentType { get; set; }

        public GKException(int StatusCode)
        {
            this.StatusCode = StatusCode;
        }

        public GKException(string Message) : base(Message)
        {
            this.StatusCode = (int)HttpStatusCode.InternalServerError;
        }

        public GKException(int StatusCode, string Message) : base(Message)
        {
            this.StatusCode = StatusCode;
        }

        public GKException(HttpStatusCode StatusCode, string Message) : base(Message)
        {
            this.StatusCode = (int)StatusCode;
        }

        public GKException(int StatusCode, Exception Inner) : this(StatusCode, Inner.ToString()) { }
        public GKException(HttpStatusCode StatusCode, Exception Inner) : this(StatusCode, Inner.ToString()) { }
        public GKException(int StatusCode, JsonElement ErrorObject) : this(StatusCode, ErrorObject.ToString()) { this.ContentType = @"application/problem+json"; }
    }
}
