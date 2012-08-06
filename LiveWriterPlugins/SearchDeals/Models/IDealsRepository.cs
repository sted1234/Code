using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchDeals.Models
{
    public interface IDealsRepository
    {
        /// <summary>
        /// Gets Predifined number of matching deals.
        /// </summary>
        IEnumerable<RawDealItem> GetDeals(string product);

        /// <summary>
        /// Gets deals on the product.
        /// </summary>
        IEnumerable<RawDealItem> GetDeals(string product, int count);
    }
}