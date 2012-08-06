using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Syndication;
using System.Xml;

namespace DealUrWayContracts
{
    public class DealSite : IDealSite
    {
        DateTime lastModified;

        string name;
        string feedUrl;

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

        public virtual IEnumerable<DealItem> GetDeals()
        {
            Uri feedUri = new Uri(FeedURL);
            XmlReader reader = XmlReader.Create(feedUri.ToString());
            SyndicationFeed feed = null;
            List<DealItem> dealItems = new List<DealItem>();
            try
            {
                feed = SyndicationFeed.Load(reader);
            }catch(Exception ex)
            {
                throw;
            }
            
            if(feed != null)
            {

                IEnumerable<SyndicationItem> syndicationItems = feed.Items;
                foreach(SyndicationItem syndicationItem in syndicationItems)
                {
                    DealItem item = new DealItem();
                    item.Title = syndicationItem.Title.Text;
                    item.URI = syndicationItem.Links[0].Uri;
                    dealItems.Add(item);
                }
            }
            return dealItems;
        }
    }


    public class FatWalletDealSite : IDealSite
    {
        DateTime lastModified;

        string name;
        string feedUrl;

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

        public virtual IEnumerable<DealItem> GetDeals()
        {
            Uri feedUri = new Uri(FeedURL);
            XmlReader reader = XmlReader.Create(feedUri.ToString());
            SyndicationFeed feed = null;
            List<DealItem> dealItems = new List<DealItem>();
            try
            {
                feed = SyndicationFeed.Load(reader);
            }
            catch (Exception ex)
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
            return dealItems;
        }
    }


}
