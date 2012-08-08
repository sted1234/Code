using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HtmlAgilityPack;

namespace DealUrWay.DealImplementor
{
    public class LivingSocial : DealProvider
    {
        public override BusinessObjects.IDealResponse GetDeals(BusinessObjects.IDealRequest request)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load("http://livingsocial.com");
            return null;
        }
    }
}
