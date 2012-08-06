using System;
using System.Net;

namespace Sandworks.Google
{
    public class IncorrectUsernameOrPasswordException : LoginFailedException
    {
        /// <summary>
        /// Fill in the exception.
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="statusDescription"></param>
        public IncorrectUsernameOrPasswordException(HttpStatusCode statusCode, string statusDescription)
            : base(statusCode, statusDescription)
        {

        }
    }
}
