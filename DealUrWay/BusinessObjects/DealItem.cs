using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealUrWay.BusinessObjects
{
    public class DealItem
    {
        public string Description { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime LastUpdatedDateTime { get; set; }
        public string Title { get; set; }
        public Uri URI { get; set; }

        /// <summary>
        /// Html Content for the deal item
        /// </summary>
        public string Html { get; set; }

        /// <summary>
        /// Content if any for the deal item
        /// </summary>
        public string Content { get; set; }
    }
}
