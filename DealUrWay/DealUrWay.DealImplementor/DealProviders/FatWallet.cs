using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DealUrWay.BusinessObjects;

namespace DealUrWay.DealImplementor
{
    class FatWallet : DealProvider
    {
        public override IDealResponse GetDeals(IDealRequest request)
        {
            return base.GetDeals(request);
        }

    }
}
