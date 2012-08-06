using System;
using System.Net;
using System.Xml;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;
using System.ServiceModel.Syndication;

namespace Sandworks.Google.Reader
{
    public class ReaderService : GoogleService
    {
        /// <summary>
        /// Current username.
        /// </summary>
        private string username;

        /// <summary>
        /// Initialize the Google reader.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="source"></param>
        public ReaderService(string username, string password, string source)
            : base("reader", username, password, source)
        {
            this.username = username;            
        }

        #region Feed
        /// <summary>
        /// Get the contents of a feed.
        /// </summary>
        /// <param name="feedUrl">
        /// Must be exact URL of the feed, ex: http://sandrinodimattia.net/blog/syndication.axd
        /// </param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public IEnumerable<ReaderItem> GetFeedContent(string feedUrl, int limit)
        {
            try
            {
                return GetItemsFromFeed(String.Format("{0}{1}", ReaderUrl.FeedUrl, System.Uri.EscapeDataString(feedUrl)), limit);
            }
            catch (WebException wex)
            {
                HttpWebResponse rsp = wex.Response as HttpWebResponse;
                if (rsp != null && rsp.StatusCode == HttpStatusCode.NotFound)
                    throw new FeedNotFoundException(feedUrl);
                else
                    throw;
            }
        }
        #endregion
        #region Subscription
        /// <summary>
        /// Subscribe to a feed.
        /// </summary>
        /// <param name="feed"></param>
        public void AddSubscription(string feed)
        {
            PostRequest(ReaderCommand.SubscriptionAdd, new GoogleParameter("quickadd",  feed));
        }

        /// <summary>
        /// Tag a subscription (remove it).
        /// </summary>
        /// <param name="feed"></param>
        /// <param name="folder"></param>
        public void TagSubscription(string feed, string folder)
        {
            PostRequest(ReaderCommand.SubscriptionEdit,
                new GoogleParameter("a", ReaderUrl.LabelPath + folder), 
                new GoogleParameter("s", "feed/" + feed), 
                new GoogleParameter("ac", "edit"));
        }

        /// <summary>
        /// Get a list of subscriptions.
        /// </summary>
        /// <returns></returns>
        public List<Subscription> GetSubscriptions()
        {
            // Get the XML for subscriptions.
            string xml = session.GetSource(ReaderCommand.SubscriptionList.GetFullUrl());

            // Get a list of subscriptions.
            return XElement.Parse(xml).Elements("list").Elements("object").Select(o => new Subscription(o)).ToList();
        }


        public string Search(string query, string count)
        {
            string xml = session.GetSource(ReaderCommand.GetSearchItemIds.GetFullUrl(), new GoogleParameter("q", query), new GoogleParameter("num", count));
            var idList = XElement.Parse(xml).Elements("list").Elements("object").Elements("number").Select(o => o.Value).ToList();

            List<GoogleParameter> gp = new List<GoogleParameter>();
            foreach(var id in idList)
            {
                gp.Add(new GoogleParameter("i", id));
            }
            gp.Add(new GoogleParameter("output","atom"));

            List<FeedSearchResult> results = new List<FeedSearchResult>();

            string resultXml = string.Empty;
            if (gp.Count > 1)
            {
                resultXml = session.GetSource(ReaderCommand.GetSearchItems.GetFullUrl(), true, gp.ToArray());
                //XNamespace xmlns = "http://www.w3.org/2005/Atom";
                //results = XElement.Parse(resultsXml).Elements(xmlns + "entry").Select(o => new FeedSearchResult(o, xmlns)).ToList<FeedSearchResult>();
            }

            return resultXml;
        }

        #endregion
        #region Tags
        /// <summary>
        /// Add tags to an item.
        /// </summary>
        /// <param name="feed"></param>
        /// <param name="folder"></param>
        public void AddTags(ReaderItem item, params string[] tags)
        {
            // Calculate the amount of parameters required.
            int arraySize = tags.Length + item.Tags.Count + 2;

            // Set all parameters.
            GoogleParameter[] parameters = new GoogleParameter[arraySize];
            parameters[0] = new GoogleParameter("s", "feed/" + item.Feed.Url);
            parameters[1] = new GoogleParameter("i", item.Id);

            int nextParam = 2;

            // Add parameters.
            for (int i = 0; i < item.Tags.Count; i++)
                parameters[nextParam++] = new GoogleParameter("a", ReaderUrl.LabelPath + item.Tags[i]);
            for (int i = 0; i < tags.Length; i++)
                parameters[nextParam++] = new GoogleParameter("a", ReaderUrl.LabelPath + tags[i]);

            // Send request.
            PostRequest(ReaderCommand.TagAdd, parameters);
        }

        /// <summary>
        /// Rename a tag.
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="newName"></param>
        public void RenameTag(string tag, string newName)
        {
            PostRequest(ReaderCommand.TagRename,
                new GoogleParameter("s", ReaderUrl.LabelPath + tag),
                new GoogleParameter("t", tag),
                new GoogleParameter("dest", ReaderUrl.LabelPath + newName));
        }

        /// <summary>
        /// Remove tag (for all items).
        /// </summary>
        /// <param name="tag"></param>
        public void RemoveTag(string tag)
        {
            PostRequest(ReaderCommand.TagDelete,
                new GoogleParameter("s", ReaderUrl.LabelPath + tag),
                new GoogleParameter("t", tag));
        }

        /// <summary>
        /// Remove tag from a single item.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="tag"></param>
        public void RemoveTag(ReaderItem item, string tag)
        {
            PostRequest(ReaderCommand.TagEdit,
                new GoogleParameter("r", ReaderUrl.LabelPath + tag),
                new GoogleParameter("s", "feed/" + item.Feed.Url),
                new GoogleParameter("i", item.Id));
        }

        /// <summary>
        /// Get a list of tags.
        /// </summary>
        /// <returns></returns>
        public List<string> GetTags()
        {            
            string xml = session.GetSource(ReaderCommand.TagList.GetFullUrl());

            // Get the list of tags.
            var tagElements = from t in XElement.Parse(xml).Elements("list").Descendants("string")
                              where t.Attribute("name").Value == "id"
                              where t.Value.Contains("/label/")
                              select t;

            // Create a list.
            List<string> tags = new List<string>();
            foreach (XElement element in tagElements)
            {
                string tag = element.Value.Substring(element.Value.LastIndexOf('/') + 1, 
                    element.Value.Length - element.Value.LastIndexOf('/') - 1);
                tags.Add(tag);
            }

            // Done.
            return tags;
        }

        /// <summary>
        /// Get all items for a tag.
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public IEnumerable<ReaderItem> GetTagItems(string tag, int limit)
        {
            return GetItemsFromFeed(String.Format("{0}{1}", ReaderUrl.LabelPath, System.Uri.EscapeDataString(tag)), limit);
        }
        #endregion
        #region State
        /// <summary>
        /// Add state for an item.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="state"></param>
        public void AddState(ReaderItem item, State state)
        {
            PostRequest(ReaderCommand.TagEdit,
                new GoogleParameter("a", ReaderUrl.StatePath + StateFormatter.ToString(state)),
                new GoogleParameter("i", item.Id),
                new GoogleParameter("s", "feed/" + item.Feed.Url));
        }

        /// <summary>
        /// Remove a state from an item.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="state"></param>
        public void RemoveState(ReaderItem item, State state)
        {
            PostRequest(ReaderCommand.TagEdit,
                new GoogleParameter("r", ReaderUrl.StatePath + StateFormatter.ToString(state)),
                new GoogleParameter("i", item.Id),
                new GoogleParameter("s", "feed/" + item.Feed.Url));
        }

        /// <summary>
        /// Get the content of a state. 
        /// For example: Get all starred items.
        /// </summary>
        /// <param name="state"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public IEnumerable<ReaderItem> GetStateItems(State state, int limit)
        {
            return GetItemsFromFeed(String.Format("{0}{1}", ReaderUrl.StateUrl, StateFormatter.ToString(state)), limit); 
        }
        #endregion

        /// <summary>
        /// Post a request using a reader command.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="postFields"></param>
        private void PostRequest(ReaderCommand command, params GoogleParameter[] postFields)
        {
            session.PostRequest(ReaderCommandFormatter.GetFullUrl(command), postFields);
        }
        
        /// <summary>
        /// Get items from a feed and convert them to a GoogleReaderItem.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        private IEnumerable<ReaderItem> GetItemsFromFeed(string url, int limit)
        {
            SyndicationFeed feed = session.GetFeed(url, new GoogleParameter("n", limit.ToString()));
            return feed.Items.Select<SyndicationItem, ReaderItem>(o => new ReaderItem(o));
        }

    }
}
