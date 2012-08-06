using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealUrWay.BusinessObjects
{
    public class DealRequest : IDealRequest
    {
        string name;
        string feedUrl;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }


        public string FeedUrl
        {
            get
            {
                return feedUrl;        
            }
            set
            {
                feedUrl = value;
            }
        }
    }
}
