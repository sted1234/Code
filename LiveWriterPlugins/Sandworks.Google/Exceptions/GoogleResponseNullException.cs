using System;

namespace Sandworks.Google
{
    public class GoogleResponseNullException : Exception
    {
        /// <summary>
        /// Fill in the exception.
        /// </summary>
        /// <param name="message"></param>
        public GoogleResponseNullException()
            : base("No or empty response received from Google.")
        {

        }
    }
}
