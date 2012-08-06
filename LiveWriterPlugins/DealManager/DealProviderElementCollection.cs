using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using DealUrWay.DealManager;

namespace DealUrWay.DealManager
{
    public class DealProviderElementCollection : ConfigurationElementCollection
    {

        /// <summary>
        /// Default constructor.
        /// </summary>
        public DealProviderElementCollection()
        {
            DealProviderElement ruleProvider = (DealProviderElement)CreateNewElement();
        }

        /// <summary>
        /// Gets the type of the ConfigurationElementCollection
        /// </summary>
        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.AddRemoveClearMap;
            }
        }

        /// <summary>
        /// Adds a ConfigurationElement to an ConfigurationElementCollection instance
        /// </summary>
        /// <param name="element">ConfigurationElement to add to the collection</param>
        protected override void BaseAdd(ConfigurationElement element)
        {
            BaseAdd(element, false);
        }

        /// <summary>
        /// Removes RuleProvider from the collection
        /// </summary>
        /// <param name="dealProvider">RuleProvider to remove</param>
        public void Remove(DealProviderElement dealProvider)
        {
            if (BaseIndexOf(dealProvider) >= 0)
            {
                BaseRemove(dealProvider.Name);
            }
        }

        /// <summary>
        /// Removes indexed element from the collection
        /// </summary>
        /// <param name="index">Index of the element to remove</param>
        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }

        /// <summary>
        /// Removes keyed element from the collection.
        /// </summary>
        /// <param name="name">Key name of the element to remove</param>
        public void Remove(string name)
        {
            BaseRemove(name);
        }

        /// <summary>
        /// Removes all configuration element objects from the collection.
        /// </summary>
        public void Clear()
        {
            BaseClear();
        }

        /// <summary>
        /// Creates a new ConfigurationElement.
        /// </summary>
        /// <returns>ConfigurationElement of type DealProviderElement</returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new DealProviderElement();
        }

        /// <summary>
        /// Gets the element key for a specified configuration element.
        /// </summary>
        /// <param name="element">Element to get the key for</param>
        /// <returns>Key of the element provided in</returns>
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((DealProviderElement)element).Name;
        }

        /// <summary>
        /// Collection accessor, returns the element requested using the provided index
        /// </summary>
        /// <param name="index">Index of the element to return</param>
        /// <returns>DealProviderElement requested</returns>
        public DealProviderElement this[int index]
        {
            get { return (DealProviderElement)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        /// <summary>
        /// Collection accessor, returns the element requested using the key name.
        /// </summary>
        /// <param name="Name">Key name of the element requested</param>
        /// <returns>DealProviderElement requested</returns>
        new public DealProviderElement this[string Name]
        {
            get { return (DealProviderElement)BaseGet(Name); }
        }

        /// <summary>
        /// Returns the index of the DealProviderElement.
        /// </summary>
        /// <param name="ruleProvider">DealProviderElement to look for</param>
        /// <returns>Index of the DealProviderElement requested</returns>
        public int IndexOf(DealProviderElement ruleProvider)
        {
            return BaseIndexOf(ruleProvider);
        }

        /// <summary>
        /// Adds the DealProviderElement to the collection.
        /// </summary>
        /// <param name="ruleProvider">DealProviderElement to add to the collection</param>
        public void Add(DealProviderElement ruleProvider)
        {
            BaseAdd(ruleProvider);
        }

    }
}
