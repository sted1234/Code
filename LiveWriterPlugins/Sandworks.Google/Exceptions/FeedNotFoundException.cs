using System;

namespace Sandworks.Google
{
    public class FeedNotFoundException : Exception
    {
        /// <summary>
        /// Fill in the exception.
        /// </summary>
        /// <param name="message"></param>
        public FeedNotFoundException(string message)
            : base(message)
        {

        }
    }
}
