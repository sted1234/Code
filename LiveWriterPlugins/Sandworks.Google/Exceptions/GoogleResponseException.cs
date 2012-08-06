using System;
using System.Net;

namespace Sandworks.Google
{
    public class GoogleResponseException : WebResponseException
    {
        /// <summary>
        /// Fill in the exception.
        /// </summary>
        /// <param name="message"></param>
        public GoogleResponseException(HttpStatusCode statusCode, string statusDescription)
            : base(statusCode, statusDescription)
        {

        }
    }
}
