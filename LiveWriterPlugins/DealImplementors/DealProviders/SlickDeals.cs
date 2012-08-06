using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects;
using System.Xml;
using System.ServiceModel.Syndication;

namespace DealImplementor
{
    public class SlickDeals : DealProvider
    {
        public override IDealResponse GetDeals(IDealRequest request)
        {
            Uri feedUri = new Uri(request.Url);
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
