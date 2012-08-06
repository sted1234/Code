using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Syndication;
using System.Web;
using System.IO;
using System.Xml;

namespace UtilityLibrary
{
    public class FeedWriter
    {
        public string BaseUrl { get; set; }
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Copyright { get; set; }
        public DateTime LastUpdatedTime { get; set; }
        public string Generator { get; set; }

        public string LinkedResource { get; set; }
        public string FeedXmlName { get; set; }

        public static void PublishFeed()
        {
            string baseUrl = "http://dealschain.com";
            SyndicationFeed feed = new SyndicationFeed();
            feed.Id = "http://dealschain.com";

            // set some properties on the feed
            feed.Title = new TextSyndicationContent("Feed Research");
            feed.Description = new TextSyndicationContent("Example Feed");
            feed.Copyright = new TextSyndicationContent("Sted");
            feed.LastUpdatedTime = new DateTimeOffset(DateTime.Now);

            // since you are writing your own custom feed generator, you get to
            // name it!  Although this is not required.
            feed.Generator = "Deals Chain";

            // Add the URL that will link to your published feed when it's done
            SyndicationLink link = new SyndicationLink(new Uri("http://dealschain.com" + "Feeds/myfeed.xml"));
            link.RelationshipType = "self";
            link.MediaType = "text/html";
            link.Title = "Test Feed";
            feed.Links.Add(link);

            // Add your site link
            link = new SyndicationLink(new Uri(baseUrl));
            link.MediaType = "text/html";
            link.Title = "Deals Chain";
            feed.Links.Add(link);

            List<SyndicationItem> items = new List<SyndicationItem>();

            int maxItems = 3;
            for (int i = 0; i < maxItems; i++)
            {

                // create new entry for feed
                SyndicationItem item = new SyndicationItem();

                // set the entry id to the URL for the item
                string url = "http://google.com";
                item.Id = url;

                // Add the URL for the item as a link
                link = new SyndicationLink(new Uri(url));
                item.Links.Add(link);

                // Fill some properties for the item
                item.Title = new TextSyndicationContent("This is a tile");
                item.LastUpdatedTime = DateTime.Now;
                item.PublishDate = DateTime.Now;

                // Fill the item content            
                string html = "<b>Hi There<b/>"; // TODO: create the GetFeedEntryHtml method
                TextSyndicationContent content
                     = new TextSyndicationContent(html, TextSyndicationContentKind.Html);
                item.Content = content;

                // Finally add this item to the item collection
                items.Add(item);

            }

            feed.Items = items;


            string mainFile = HttpContext.Current.Server.MapPath("~/Feeds/TestFeed.xml");
            using (FileStream fs = new FileStream(mainFile, FileMode.OpenOrCreate))
            {
                using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                {
                    XmlWriterSettings xs = new XmlWriterSettings();
                    xs.Indent = true;
                    using (XmlWriter xw = XmlWriter.Create(w, xs))
                    {
                        xw.WriteStartDocument();
                        Atom10FeedFormatter formatter = new Atom10FeedFormatter(feed);
                        //Rss20FeedFormatter formatter = new Rss20FeedFormatter(feed);
                        formatter.WriteTo(xw);
                        xw.Close();
                    }
                }
            }
        }
    }
}
