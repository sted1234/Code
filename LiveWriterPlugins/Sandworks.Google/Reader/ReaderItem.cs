using System;
using System.Linq;
using System.Collections.Generic;
using System.ServiceModel.Syndication;

using Sandworks.Google.Base;

namespace Sandworks.Google.Reader
{
    public class ReaderItem : GoogleSyndicationItem
    {
        /// <summary>
        /// Google Id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Author of the item.
        /// </summary>
        public string Author { get; private set; }

        /// <summary>
        /// Direct link to the item.
        /// </summary>
        public Uri Url { get; private set; }

        /// <summary>
        /// Title of the item.
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// Summary of the item.
        /// </summary>
        public string Summary { get; private set; }

        /// <summary>
        /// The feed owning this item.
        /// </summary>
        public Feed Feed { get; private set; }

        /// <summary>
        /// Update time.
        /// </summary>
        public DateTimeOffset UpdateTime { get; private set; }

        /// <summary>
        /// Publish date.
        /// </summary>
        public DateTimeOffset PublishDate { get; private set; }

        /// <summary>
        /// List of tags applied to the item.
        /// </summary>
        public List<string> Tags { get; private set; }
        
        /// <summary>
        /// List of states applied to the item.
        /// </summary>
        public List<State> States { get; private set; }
        
        /// <summary>
        /// Initialize the reader item.
        /// </summary>
        /// <param name="item"></param>
        internal ReaderItem(SyndicationItem item)
            : base(item)
        {

        }

        /// <summary>
        /// Load the item.
        /// </summary>
        /// <param name="item"></param>
        protected override void  LoadItem(SyndicationItem item)
        { 	
            // Initialize the lists.
            Tags = new List<string>();
            States = new List<State>();

            // Get the regular fields.
            Id = item.Id;
            PublishDate = item.PublishDate;
            UpdateTime = item.LastUpdatedTime;
            Title = GetTextSyndicationContent(item.Title);

            // Get the summary.
            Summary = GetTextSyndicationContent(item.Summary);
            if (String.IsNullOrEmpty(Summary))
                Summary = GetTextSyndicationContent(item.Content);

            // Get items from a list.
            if (item.Authors.Count > 0)
                Author = item.Authors[0].Name;
            if (item.Links.Count > 0)
                Url = item.Links[0].Uri;

            // Get labels/categories.
            foreach (var cat in item.Categories)
            {
                State state = StateFormatter.ToState(cat.Label);
                if (state != State.Label && state != State.Unknown)
                    States.Add(state);
            }

            // Add tags.
            foreach (var cat in item.Categories)
            {
                if (cat.Name.EndsWith("/label/" + cat.Label))
                    Tags.Add(cat.Label);
            }

            // Get the feed.
            this.Feed = new Feed(item);
        }
    }
}
