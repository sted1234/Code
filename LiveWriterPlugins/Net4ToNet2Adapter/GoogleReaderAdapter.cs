using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sandworks.Google;
using System.Runtime.InteropServices;
using System.ServiceModel;
using System.ServiceModel.Syndication;

namespace Net4ToNet2Adapter
{
    [ComVisible(true)]
    [Guid("A6574755-925A-4E41-A01B-B6A0EEF72DF0")]
    class GoogleReaderAdapter :  IGoogleReaderAdapter
    {
        public StringBuilder GetHTML(string feedUrl, string username, string password)
        {
            // Authenticate.
            string auth = ClientLogin.GetAuthToken("reader", username, password, "Sandworks.Google.App");

            // Query.
            using (GoogleSession session = new GoogleSession(auth))
            {
                DateTime d = new DateTime(2011, 12, 25);

                var feed = session.GetFeed("http://www.google.com/reader/atom/user/-/state/com.google/starred",
                    new GoogleParameter("n", "200"), new GoogleParameter("ot", session.GetUnixTimeNow().ToString()));

                foreach (var item in feed.Items)
                {
                    //Console.WriteLine("Author: " + item.Authors[0].Name);
                    //Console.WriteLine("Link: " + item.Links[0].Uri);
                    //Console.WriteLine("Title: " + item.Title.Text);
                    //Console.WriteLine();
                }
            }

            return new StringBuilder("suman");
        }
    }
}
