using System;
using System.Net;

namespace Sandworks.Google
{
    public class WebResponseException : Exception
    {
        /// <summary>
        /// Status code sent by the server.
        /// </summary>
        public HttpStatusCode StatusCode { get; private set; }

        /// <summary>
        /// Fill in the exception.
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="statusDescription"></param>
        public WebResponseException(HttpStatusCode statusCode, string statusDescription)
            : base(statusDescription)
        {
            this.StatusCode = statusCode;
        }
    }
}
