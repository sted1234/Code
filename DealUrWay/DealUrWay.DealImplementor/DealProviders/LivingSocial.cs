using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HtmlAgilityPack;
using UtilityLibrary;
using DealUrWay.BusinessObjects;
using System.Threading.Tasks;

namespace DealUrWay.DealImplementor
{
    public class LivingSocial : DealProvider
    {
        public override BusinessObjects.IDealResponse GetDeals(BusinessObjects.IDealRequest request)
        {
            List<string> links = HtmlHelper.GetLinksFromUrl(this.FeedURL);
            List<DealItem> dealItems = new List<DealItem>();
            Parallel.ForEach(links, (link) => dealItems.Add(new DealItem { Title = link, URI = new Uri(link) }));
            return new DealResponse { DealItems = dealItems };
        }
    }
}
