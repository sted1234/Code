using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace DealUrWay.DealManager
{
    public class DealProviderSection : ConfigurationSection
    {
        #region Private Keys
        private const string ProvidersKey = "DealProviders";
        #endregion

        [ConfigurationProperty(ProvidersKey, IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(DealProviderElementCollection), AddItemName="AddDealProvider", ClearItemsName="ClearDealProvider", RemoveItemName="RemoveDealProvider")]
        public DealProviderElementCollection DealProviders
        {
            get
            {
                return (DealProviderElementCollection)this[ProvidersKey];
            }
        }

    }
}
