using System;
using System.ServiceModel.Syndication;

using Sandworks.Google.Base;

namespace Sandworks.Google.Reader
{
    public class Feed : GoogleSyndicationItem
    {
        /// <summary>
        /// Title of the feed.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// URL to the site.
        /// </summary>
        public Uri Url { get; set; }

        /// <summary>
        /// Initialize the feed.
        /// </summary>
        /// <param name="item"></param>
        internal Feed(SyndicationItem item)
            : base(item)
        {

        }

        /// <summary>
        /// Load the feed.
        /// </summary>
        /// <param name="item"></param>
        protected override void LoadItem(SyndicationItem item)
        { 	
            if (item.SourceFeed != null)
            {
                if (item.SourceFeed.Title != null)
                    Title = item.SourceFeed.Title.Text;
                if (item.SourceFeed.Links != null && item.SourceFeed.Links.Count > 0)    
                    Url = item.SourceFeed.Links[0].Uri;
            }
        }
    }
}
