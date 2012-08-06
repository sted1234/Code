using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects;

namespace DealUrWay.DealManager
{
    public class DealManager
    {
        public static IDealResponse GetDeals(IDealRequest request)
        {

            string dealSiteName = request.Name;
            if (string.IsNullOrWhiteSpace(dealSiteName))
            {
                throw new Exception("Site Name cannot be empty");
            }

            IDealProvider dealProvider = DealSiteFactory.GetProvider(request);

            return dealProvider.GetDeals(request);


        }

        public static IEnumerable<string> GetDealProviders()
        {
            IEnumerable<string> dealProviders = DealProviderSectionManager.GetAllProviders();
            return dealProviders;
        }

    }
}
