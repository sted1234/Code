using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSSFeedToBlog
{
    public class Link
    {
        public string Title { get; set; }
        public string HyperLink { get; set; }
        public string AuthorName { get; set; }
        public string Category { get; set; }
        public bool IsCategorized { get; set; }
    }
}
