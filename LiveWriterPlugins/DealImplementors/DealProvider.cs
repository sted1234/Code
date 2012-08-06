using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Xml;
using BusinessObjects;


using System.Configuration;
using System.ServiceModel.Syndication;

namespace DealImplementor
{
    public abstract class DealProvider : IDealProvider
    {
        DateTime lastModified;

        string name;
        string url;

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

        public string URL
        {
            get
            {
                return url;
            }
            set
            {
                url = value;
            }

        }

        public DateTime LastModified
        {
            get
            {
                return lastModified;
            }
            set
            {
                lastModified = value;
            }
        }

        public abstract IDealResponse GetDeals(IDealRequest request);

    }

}
