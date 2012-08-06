using System;

namespace Sandworks.Google
{
    public abstract class GoogleService : IDisposable
    {
        /// <summary>
        /// Current google session.
        /// </summary>
        protected GoogleSession session;

        /// <summary>
        /// Creating this class will automatically try to log in and create a session.
        /// That way for each service we create we don't need to worry about the implementation of authentication and session.
        /// </summary>
        /// <param name="service"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="source"></param>
        protected GoogleService(string service, string username, string password, string source)
        {
            // Get the Auth token.
            string auth = ClientLogin.GetAuthToken(service, username, password, source);

            // Create a new session using this token.
            this.session = new GoogleSession(auth);
        }

        /// <summary>
        /// Clean up the session.
        /// </summary>
        public void Dispose()
        {
            if (session != null)
                session.Dispose();
        }
    }
}
