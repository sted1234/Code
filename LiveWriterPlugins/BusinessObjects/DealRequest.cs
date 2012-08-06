using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects
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


        public string Url
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
