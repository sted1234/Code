using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchDeals.Models
{
    public interface IDealsProcessor
    {
        /// <summary>
        /// Gets Predifined number of matching deals.
        /// </summary>
        IEnumerable<DealItem> GetDeals(string product);

        /// <summary>
        /// Gets deals on the product.
        /// </summary>
        IEnumerable<DealItem> GetDeals(string product, int count);

    }
}