using System;
using System.ServiceModel.Syndication;

namespace Sandworks.Google.Base
{
    public abstract class GoogleSyndicationItem
    {
        /// <summary>
        /// Initialize the item.
        /// </summary>
        /// <param name="item"></param>
        internal GoogleSyndicationItem(SyndicationItem item)
        {
            if (item != null)
            {
                LoadItem(item);
            }
        }

        /// <summary>
        /// Load the item (to be implemented by inheriting classes).
        /// </summary>
        /// <param name="item"></param>
        protected abstract void LoadItem(SyndicationItem item);

        /// <summary>
        /// Get the text from a TextSyndicationContent.
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public string GetTextSyndicationContent(SyndicationContent content)
        {
            TextSyndicationContent txt = content as TextSyndicationContent;
            if (txt != null)
                return txt.Text;
            else
                return "";
        }
    }
}
