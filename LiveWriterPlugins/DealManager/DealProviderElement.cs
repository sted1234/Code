using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace DealUrWay.DealManager
{

    public class DealProviderElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public string Name
        {
            get
            {
                return this["name"].ToString();
            }
            set
            {
                this["name"] = value;
            }
        }

        [ConfigurationProperty("FeedURL", IsRequired = true)]
        public string FeedUrl
        {
            get
            {
                return this["FeedURL"].ToString();
            }
            set
            {
                this["FeedURL"] = value;
            }
        }

        [ConfigurationProperty("ProviderAssemblyName", IsRequired = true)]
        public string ProviderAssemblyName
        {
            get
            {
                return this["ProviderAssemblyName"].ToString();
            }
            set
            {
                this["ProviderAssemblyName"] = value;
            }
        }

        [ConfigurationProperty("ProviderClass", IsRequired = true)]
        public string ProviderClass
        {
            get
            {
                return this["ProviderClass"].ToString();
            }
            set
            {
                this["ProviderClass"] = value;
            }
        }

        


    }

   
}
