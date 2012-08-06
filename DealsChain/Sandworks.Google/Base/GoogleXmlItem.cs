using System;
using System.Linq;
using System.Xml.Linq;
using System.ServiceModel.Syndication;
using System.Collections.Generic;

namespace Sandworks.Google.Base
{
    public abstract class GoogleXmlItem : SyndicationItem
    {
        /// <summary>
        /// Initialize the item.
        /// </summary>
        /// <param name="item"></param>
        internal GoogleXmlItem(XElement item)
        {
            if (item != null)
            {
                LoadItem(item);
            }
        }

                /// <summary>
        /// Initialize the item.
        /// </summary>
        /// <param name="item"></param>
        internal GoogleXmlItem(XElement item, XNamespace xmlNamespace)
        {
            if (item != null)
            {
                LoadItem(item, xmlNamespace);
            }
        }

        /// <summary>
        /// Load the item (to be implemented by inheriting classes).
        /// </summary>
        /// <param name="item"></param>
        protected abstract void LoadItem(XElement item);

        /// <summary>
        /// Load the item (to be implemented by inheriting classes).
        /// </summary>
        /// <param name="item"></param>
        protected abstract void LoadItem(XElement item, XNamespace xmlNamespace);


        /// <summary>
        /// Get a list of descendants.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="descendant"></param>
        /// <param name="attribute"></param>
        /// <param name="attributeValue"></param>
        /// <returns></returns>
        protected IEnumerable<XElement> GetDescendants(XElement item, string descendant, string attribute, string attributeValue)
        {
            return item.Descendants(descendant).Where(o => o.Attribute(attribute) != null && o.Attribute(attribute).Value == attributeValue);
        }

        /// <summary>
        /// Get a descendant.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="descendant"></param>
        /// <param name="attribute"></param>
        /// <param name="attributeValue"></param>
        /// <returns></returns>
        protected XElement GetDescendant(XElement item, string descendant, string attribute, string attributeValue)
        {
            return GetDescendants(item, descendant, attribute, attributeValue).First();
        }

        /// <summary>
        /// Get the value of a descendant.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="descendant"></param>
        /// <param name="attribute"></param>
        /// <param name="attributeValue"></param>
        /// <returns></returns>
        protected string GetDescendantValue(XElement item, string descendant, string attribute, string attributeValue)
        {
            var desc = GetDescendant(item, descendant, attribute, attributeValue);
            if (desc != null)
                return desc.Value;
            else
                return "";
        }


        protected string GetChildValue(XElement item, string name)
        {
            XElement element = item.Element(name);
            if (element == null)
                return string.Empty;
            else
                return element.Value;
        }

        protected string GetChildValue(XElement item, string name, XNamespace xmlNamespace)
        {
            XElement element = item.Element(xmlNamespace + name);
            if (element == null)
                return string.Empty;
            else
                return element.Value;
        }
    }
}
