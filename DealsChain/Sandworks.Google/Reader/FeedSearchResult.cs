using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sandworks.Google.Base;
using System.Xml.Linq;
using System.Globalization;

namespace Sandworks.Google.Reader
{
    public class FeedSearchResult : GoogleXmlItem
    {
        /// <summary>
        /// Title of the Item.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Time Item published
        /// </summary>
        public DateTime Published { get; set;}

        /// <summary>
        /// Time Item Updated
        /// </summary>
        public DateTime Updated {get; set;}

        /// <summary>
        /// URL to the Item
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Author of the item
        /// </summary>
        public string Author { get; set; }
        
        /// <summary>
        /// Html Summary on the item
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// List of categories.
        /// </summary>
        public List<string> Categories { get; set; }

        public string Source { get; set; }

        public string SourceUrl { get; set; }
        /// <summary>
        /// Namespace used to extract xml elements
        /// </summary>
        public XNamespace XmlNamespace { get; set; }


        public string DisplayDate
        {
            get
            {
                TimeSpan ts = DateTime.Now.Subtract(Published);
                if (ts.Days == 0)
                {
                    return Published.ToString("hh:mm tt", CultureInfo.InvariantCulture);
                }
                else if (ts.Days == 1)
                {
                    return Published.ToString("MMM d", CultureInfo.InvariantCulture);
                }
                else
                {
                    return Published.ToString("MMM d", CultureInfo.InvariantCulture);
                }
                return string.Empty;
            }
        }

        /// <summary>
        /// Initialize the subscription.
        /// </summary>
        /// <param name="item"></param>
        internal FeedSearchResult(XElement item, XNamespace xmlNamespace)
            : base(item, xmlNamespace)
        {
            this.XmlNamespace = xmlNamespace;
        }

        /// <summary>
        /// Load the subscription item.
        /// </summary>
        /// <param name="item"></param>
        protected override void LoadItem(XElement item)
        {
            throw new NotImplementedException();
        }



        protected override void LoadItem(XElement item, XNamespace xmlNamespace)
        {
            Title = GetChildValue(item, "title", xmlNamespace);

            Published = Convert.ToDateTime(GetChildValue(item, "published", xmlNamespace));

            Updated = Convert.ToDateTime(GetChildValue(item, "updated", xmlNamespace));

            Summary = GetChildValue(item, "summary", xmlNamespace);

            Source = GetChildValue(item.Element(xmlNamespace + "source"), "title", xmlNamespace);

            SourceUrl = item.Element(xmlNamespace + "source").Element(xmlNamespace + "link").Attribute("href").Value;

            if (Summary == string.Empty)
                Summary = GetChildValue(item, "content", xmlNamespace);

            Url = item.Element(xmlNamespace + "link").Attribute("href").Value;

            Author = item.Element(xmlNamespace + "author").Element(xmlNamespace + "name").Value;

        }
    }
}
