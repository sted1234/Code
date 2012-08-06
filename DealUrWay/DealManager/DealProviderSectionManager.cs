using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DealUrWay.BusinessObjects;
using DealUrWay.DealManager;

namespace DealUrWay.DealManager
{
    public static class DealProviderSectionManager
    {
        static DealProviderSection section;
            
        static DealProviderSectionManager ()
	    {
            section = (DealProviderSection)System.Configuration.ConfigurationManager.GetSection("DealProvidersSection");

	    }



        internal static IEnumerable<string> GetAllProviders()
        {
            List<string> dealProviders = new List<string>();
            foreach (DealProviderElement dealProvider in section.DealProviders)
            {
                dealProviders.Add(dealProvider.Name);
            }
            return dealProviders;
        }
    }
}
