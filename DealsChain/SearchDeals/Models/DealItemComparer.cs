using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchDeals.Models
{
    public class DealItemComparer : IEqualityComparer<RawDealItem>
    {
        public bool Equals(RawDealItem x, RawDealItem y)
        {
            return x.Title.Equals(y.Title, StringComparison.InvariantCultureIgnoreCase);
        }

        public int GetHashCode(RawDealItem obj)
        {
            return (obj.Title).GetHashCode();
        }
    }

}