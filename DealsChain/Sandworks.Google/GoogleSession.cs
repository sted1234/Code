using System;
using System.IO;
using System.Net;
using System.Xml;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.ServiceModel.Syndication;

namespace Sandworks.Google
{
    public class GoogleSession : IDisposable
    {
        /// <summary>
        /// Auth token.
        /// </summary>
        private string auth;

        /// <summary>
        /// Auth token.
        /// </summary>
        public string AuthToken
        {
            get { return auth; }
        }

        /// <summary>
        /// Url to get the token.
        /// </summary>
        private string tokenUrl = "http://www.google.com/reader/api/0/token";

        /// <summary>
        /// Initialize request.
        /// </summary>
        /// <param name="auth"></param>
        public GoogleSession(string auth)
        {
            this.auth = auth;
        }

        /// <summary>
        /// Get a token to create edit/add/... requests.
        /// </summary>
        /// <returns></returns>
        public string GetToken()
        {
            return GetSource(tokenUrl);
        }
        
        /// <summary>
        /// Create a google request and get the response.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public WebResponse GetResponse(string url, params GoogleParameter[] parameters)
        {
            // Format the parameters.
            string formattedParameters = string.Empty;
            foreach (var par in parameters)
                formattedParameters += string.Format("{0}={1}&", par.Name, par.Value);
            formattedParameters = formattedParameters.TrimEnd('&');

            // Create a request with or without parameters.
            HttpWebRequest request = null;
            if (formattedParameters.Length > 0)
                request = (HttpWebRequest)WebRequest.Create(string.Format("{0}?{1}", 
                    url, formattedParameters));
            else 
                request = (HttpWebRequest)WebRequest.Create(url);

            // Add the authentication header. 
            request.Headers.Add("Authorization", "GoogleLogin auth=" + auth);

            // Get the response, validate and return.
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            if (response == null)
                throw new GoogleResponseNullException();
            else if (response.StatusCode != HttpStatusCode.OK)
                throw new GoogleResponseException(response.StatusCode, 
                    response.StatusDescription);
            return response;
        }


        /// <summary>
        /// Create a google request and get the response.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public WebResponse GetResponseUsingPost(string url, params GoogleParameter[] postFields)
        {
            // Format the parameters.
            string formattedParameters = string.Empty;
            foreach (var par in postFields.Where(o => o != null))
                formattedParameters += string.Format("{0}={1}&", par.Name, par.Value);
            formattedParameters = formattedParameters.TrimEnd('&');

            // Append a token.
            formattedParameters += String.Format("&{0}={1}", "T", GetToken());

            // Get the current post data and encode.
            ASCIIEncoding ascii = new ASCIIEncoding();
            byte[] encodedPostData = ascii.GetBytes(
                String.Format(formattedParameters));

            // Prepare request.
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = encodedPostData.Length;

            // Add the authentication header. 
            request.Headers.Add("Authorization", "GoogleLogin auth=" + auth);

            // Write parameters to the request.
            using (Stream newStream = request.GetRequestStream())
                newStream.Write(encodedPostData, 0, encodedPostData.Length);

            // Get the response, validate and return.
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            if (response == null)
                throw new GoogleResponseNullException();
            else if (response.StatusCode != HttpStatusCode.OK)
                throw new GoogleResponseException(response.StatusCode,
                    response.StatusDescription);
            return response;
        }




        /// <summary>
        /// Send a post request to Google.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postFields"></param>
        /// <returns></returns>
        public void PostRequest(string url, params GoogleParameter[] postFields)
        {
            // Format the parameters.
            string formattedParameters = string.Empty;
            foreach (var par in postFields.Where(o => o != null))
                formattedParameters += string.Format("{0}={1}&", par.Name, par.Value);
            formattedParameters = formattedParameters.TrimEnd('&');

            // Append a token.
            formattedParameters += String.Format("&{0}={1}", "T", GetToken());
            
            // Get the current post data and encode.
            ASCIIEncoding ascii = new ASCIIEncoding();
            byte[] encodedPostData = ascii.GetBytes(
                String.Format(formattedParameters));

            // Prepare request.
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = encodedPostData.Length;
            
            // Add the authentication header. 
            request.Headers.Add("Authorization", "GoogleLogin auth=" + auth);

            // Write parameters to the request.
            using (Stream newStream = request.GetRequestStream())
                newStream.Write(encodedPostData, 0, encodedPostData.Length);

            // Get the response and validate.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode != HttpStatusCode.OK)
                throw new LoginFailedException(
                    response.StatusCode, response.StatusDescription);
            response.Close();
        }

        /// <summary>
        /// Create a google request and get the response stream.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Stream GetResponseStream(string url, bool isPost, params GoogleParameter[] parameters)
        {
            if (!isPost)
                return GetResponse(url, parameters).GetResponseStream();
            else
                return GetResponseUsingPost(url, parameters).GetResponseStream();
        }

        /// <summary>
        /// Create a google request and get the page source.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public string GetSource(string url, bool isPost, params GoogleParameter[] parameters)
        {
            using (StreamReader reader = new StreamReader(GetResponseStream(url, isPost, parameters)))
            {
                return reader.ReadToEnd();
            }

        }


        /// <summary>
        /// Create a google request and get the page source.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public string GetSource(string url, params GoogleParameter[] parameters)
        {
            using (StreamReader reader = new StreamReader(GetResponseStream(url, false, parameters)))
            {
                return reader.ReadToEnd();
            }

        }


        /// <summary>
        /// Create a google request and get the feed.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public SyndicationFeed GetFeed(string url, params GoogleParameter[] parameters)
        {
            // Load the stream into the reader.
            using (StreamReader reader = new StreamReader(
                GetResponseStream(url, false, parameters)))
            {
                // Create an xml reader out of the stream reader.
                using (XmlReader xmlReader = XmlReader.Create(reader, 
                    new XmlReaderSettings()))
                {
                    // Get a syndication feed out of the xml.
                    return SyndicationFeed.Load(xmlReader);    
                }                
            }
        }

        public long GetUnixTimeNow()
        {
            TimeSpan ts = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));
            long unixTime = (long)ts.TotalSeconds;
            return unixTime;
        }


        /// <summary>
        /// Clean up the authentication token.
        /// </summary>
        public void Dispose()
        {
            auth = null;
        }
    }
}
