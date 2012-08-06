using System;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;
using System.ServiceModel.Syndication;

using Sandworks.Google.Base;

namespace Sandworks.Google.Reader
{
    public class Subscription : GoogleXmlItem
    {
        /// <summary>
        /// Id of the subscription.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Title of the feed.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// URL to the subscription.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// List of categories.
        /// </summary>
        public List<string> Categories { get; set; }

        /// <summary>
        /// Initialize the subscription.
        /// </summary>
        /// <param name="item"></param>
        internal Subscription(XElement item)
            : base(item)
        {

        }

        /// <summary>
        /// Load the subscription item.
        /// </summary>
        /// <param name="item"></param>
        protected override void LoadItem(XElement item)
        {
            // Initialize categories list.
            Categories = new List<string>();

            // Regular fields.
            Id = GetDescendantValue(item, "string", "name", "id");
            Title = GetDescendantValue(item, "string", "name", "title");

            // Parse the URL.
            if (Id.Contains('/'))
                Url = Id.Substring(Id.IndexOf('/') + 1, Id.Length - Id.IndexOf('/') - 1);

            // Get the categories.
            var catList = GetDescendant(item, "list", "name", "categories");
            if (catList != null && catList.HasElements)
            {
                var categories = GetDescendants(item, "string", "name", "label");
                Categories.AddRange(categories.Select(o => o.Value));
            }
        }

        protected override void LoadItem(XElement item, XNamespace xmlNamespace)
        {
            throw new NotImplementedException();
        }
    }
}
