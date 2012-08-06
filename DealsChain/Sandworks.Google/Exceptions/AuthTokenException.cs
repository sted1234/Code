using System;

namespace Sandworks.Google
{
    public class AuthTokenException : Exception
    {
        /// <summary>
        /// Fill in the exception.
        /// </summary>
        /// <param name="message"></param>
        public AuthTokenException(string message)
            : base(message)
        {

        }
    }
}
