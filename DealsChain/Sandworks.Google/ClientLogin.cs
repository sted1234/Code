using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Sandworks.Google
{
    public static class ClientLogin
    {
        /// <summary>
        /// Client login url where we'll post login data to.
        /// </summary>
        private static string clientLoginUrl = 
            @"https://www.google.com/accounts/ClientLogin";

        /// <summary>
        /// Data to be sent with the post request.
        /// </summary>
        private static string postData = 
            @"service={0}&continue=http://www.google.com/&Email={1}&Passwd={2}&source={3}";

        /// <summary>
        /// Get the Auth token you get after a successful login. 
        /// You'll need to reuse this token in the header of each new request you make.
        /// </summary>
        /// <param name="service"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string GetAuthToken(
            string service, string username, string password, string source)
        {
            // Get the response that needs to be parsed.
            string response = PostRequest(service, username, password, source);

            // Get auth token.
            string auth = ParseAuthToken(response);
            return auth;
        }

        /// <summary>
        /// Parse the Auth token from the response.
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        private static string ParseAuthToken(string response)
        {            
            // Get the auth token.
            string auth = "";
            try
            {
                auth = new Regex(@"Auth=(?<auth>\S+)").Match(response).Result("${auth}");
            }
            catch (Exception ex)
            {
                throw new AuthTokenException(ex.Message);
            }

            // Validate token.
            if (string.IsNullOrEmpty(auth))
            {
                throw new AuthTokenException("Missing or invalid 'Auth' token.");
            }

            // Use this token in the header of each new request.
            return auth;
        }

        /// <summary>
        /// Create a post request with all the login data. This will return something like:
        /// 
        /// SID=AQAAAH1234
        /// LSID=AQAAAH8AA5678
        /// Auth=AQAAAIAAAAB910
        /// 
        /// And we need the Auth token for each subsequent request.
        /// </summary>
        /// <param name="service"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        private static string PostRequest(
            string service, string email, string password, string source)
        {
            // Get the current post data and encode.
            ASCIIEncoding ascii = new ASCIIEncoding();
            byte[] encodedPostData = ascii.GetBytes(
                String.Format(postData, service, email, password, source));
            
            // Prepare request.
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(clientLoginUrl);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = encodedPostData.Length;

            // Write login info to the request.
            using (Stream newStream = request.GetRequestStream())
                newStream.Write(encodedPostData, 0, encodedPostData.Length);

            // Get the response that will contain the Auth token.
            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                HttpWebResponse faultResponse = ex.Response as HttpWebResponse;
                if (faultResponse != null && faultResponse.StatusCode == HttpStatusCode.Forbidden)
                    throw new IncorrectUsernameOrPasswordException(
                        faultResponse.StatusCode, faultResponse.StatusDescription);
                else
                    throw;
            }

            // Check for login failed.
            if (response.StatusCode != HttpStatusCode.OK)
                throw new LoginFailedException(
                    response.StatusCode, response.StatusDescription);

            // Read.
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                return reader.ReadToEnd();
        }
    }
}
