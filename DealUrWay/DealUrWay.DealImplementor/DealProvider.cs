using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Syndication;
using System.Xml;
using DealUrWay.BusinessObjects;

using DealUrWay.DealManager;
using System.Configuration;

namespace DealUrWay.DealImplementor
{
    public class DealProvider : IDealProvider
    {
        DateTime lastModified;

        string name;
        string feedUrl;
        string configFile;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string FeedURL
        {
            get
            {
                return feedUrl;
            }
            set
            {
                feedUrl = value;
            }

        }

        public string ConfigFile
        {
            get
            {
                return configFile;
            }
            set
            {
                configFile = value;
            }
        }


        public DateTime LastModified
        {
            get
            {
                return lastModified;
            }
            set
            {
                lastModified = value;
            }
        }


        public virtual IDealResponse GetDeals(IDealRequest request)
        {
            Uri feedUri = new Uri(this.FeedURL);
            XmlReader reader = XmlReader.Create(feedUri.ToString());
            SyndicationFeed feed = null;
            List<DealItem> dealItems = new List<DealItem>();
            try
            {
                feed = SyndicationFeed.Load(reader);
            }
            catch (Exception)
            {
                throw;
            }

            if (feed != null)
            {

                IEnumerable<SyndicationItem> syndicationItems = feed.Items;
                foreach (SyndicationItem syndicationItem in syndicationItems)
                {
                    DealItem item = new DealItem();
                    item.Title = syndicationItem.Title.Text;
                    item.URI = syndicationItem.Links[0].Uri;
                    dealItems.Add(item);
                }
            }
            DealResponse response = new DealResponse { DealItems = dealItems };
            return response;
            
        }


    }

}
