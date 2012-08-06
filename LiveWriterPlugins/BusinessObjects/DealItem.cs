using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects
{
    public class DealItem
    {
        public string Description { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
        public string Title { get; set; }
        public Uri URI { get; set; }
        public Uri Image { get; set; }
    }
}
