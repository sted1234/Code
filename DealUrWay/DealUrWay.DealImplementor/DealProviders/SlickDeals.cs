using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DealUrWay.BusinessObjects;

namespace DealUrWay.DealImplementor
{
    public class SlickDeals : DealProvider
    {
        public override IDealResponse GetDeals(IDealRequest request)
        {
            return base.GetDeals(request);
        }
    }
}
