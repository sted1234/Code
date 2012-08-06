using System;
using System.Net;

namespace Sandworks.Google
{
    public class LoginFailedException : WebResponseException
    {
        /// <summary>
        /// Fill in the exception.
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="statusDescription"></param>
        public LoginFailedException(HttpStatusCode statusCode, string statusDescription)
            : base(statusCode, statusDescription)
        {

        }
    }
}
