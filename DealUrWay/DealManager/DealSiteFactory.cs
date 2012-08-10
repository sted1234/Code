using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DealUrWay.BusinessObjects;
using DealUrWay.DealManager;

namespace DealUrWay.DealManager
{
    public class DealSiteFactory
    {
        

        internal static IDealProvider GetProvider(IDealRequest request)
        {
            DealProviderSection section = (DealProviderSection)System.Configuration.ConfigurationManager.GetSection("DealProvidersSection");
            IDealProvider provider = null;

            foreach (DealProviderElement v in section.DealProviders)
            {
                if (v.Name.Equals(request.Name, StringComparison.InvariantCultureIgnoreCase))
                {
                    provider = (IDealProvider)BuildProvider(v.ProviderAssemblyName, v.ProviderClass);
                    provider.FeedURL = v.FeedUrl;
                    provider.Name = v.Name;
                    provider.ConfigFile = v.ConfigurationFile;
                }
            }

            return provider;
        }

        private static object BuildProvider(string assemblyName, string className)
        {

            if (string.IsNullOrWhiteSpace(assemblyName))
            {
                throw new Exception("Assembly Name cannot be empty");
            }

            if (string.IsNullOrWhiteSpace(className))
            {
                throw new Exception("Class Name cannot be empty");
            }


            System.Runtime.Remoting.ObjectHandle objHandle =
                System.Activator.CreateInstance(assemblyName, className);

            return objHandle.Unwrap();

        }



    }
}
