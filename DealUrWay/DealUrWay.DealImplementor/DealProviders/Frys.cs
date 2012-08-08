using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealUrWay.DealImplementor.DealProviders
{
    public class Frys : DealProvider
    {
        public override BusinessObjects.IDealResponse GetDeals(BusinessObjects.IDealRequest request)
        {
            return base.GetDeals(request);
        }
    }
}
