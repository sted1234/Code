using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.Xml.Linq;

namespace SearchDeals.Models
{
    public class DealItem
    {
        /// <summary>
        /// Title of the Item.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Time Item published
        /// </summary>
        public DateTime Published { get; set; }

        /// <summary>
        /// Time Item Updated
        /// </summary>
        public DateTime Updated { get; set; }

        /// <summary>
        /// URL to the Item
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Author of the item
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Html Summary on the item
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// List of categories.
        /// </summary>
        public List<string> Categories { get; set; }

        public string Source { get; set; }

        public string SourceUrl { get; set; }
        /// <summary>
        /// Namespace used to extract xml elements
        /// </summary>
        public XNamespace XmlNamespace { get; set; }


        public string DisplayDate
        {
            get
            {
                DateTime currentTime = DateTime.Now;
                TimeSpan timeSincePublished = DateTime.Now.Subtract(Published);

                // If published today
                if (timeSincePublished.Hours < 24 && Published.Day == currentTime.Day)
                {
                    string timeComponent = string.Empty;
                    if(timeSincePublished.Hours > 0)
                        timeComponent = string.Format("({0} hours ago)", timeSincePublished.Hours);
                    else if(timeSincePublished.Minutes > 1)
                        timeComponent = string.Format("({0} minutes ago)", timeSincePublished.Minutes);
                    else
                        timeComponent = string.Format("(seconds ago)");
                    return Published.ToString("hh:mm tt", CultureInfo.InvariantCulture) + " " + timeComponent;
                }
                // if published yesterday but with in 24 hours
                else if(timeSincePublished.Hours < 24 && Published.AddDays(1).Day == currentTime.Day)
                {
                    return Published.ToString("MMM d", CultureInfo.InvariantCulture) + " " + string.Format("({0} hours ago)", timeSincePublished.Hours);
                }
                // if published yesterday but more than 24 hours
                else if (timeSincePublished.Hours > 24 && Published.AddDays(1).Day == currentTime.Day)
                {
                    return Published.ToString("MMM d", CultureInfo.InvariantCulture) + " " + "(Yesterday)";
                }
                // published more than 1 day back
                else
                {
                    int daysBefore = DateTime.Now.Subtract(Published).Days;
                    if (Published.AddDays(daysBefore).Day != currentTime.Day)
                        daysBefore++;
                    return Published.ToString("MMM d", CultureInfo.InvariantCulture) + " " + string.Format("({0} days ago)", daysBefore);
                }
            }
        }

    }
}