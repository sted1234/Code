using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace DealUrWay.BusinessObjects
{
    public interface IDealProvider
    {
        string Name { get; set; }
        string FeedURL { get; set; }
        DateTime LastModified { get; set; }

        IDealResponse GetDeals(IDealRequest request);
    }
}
