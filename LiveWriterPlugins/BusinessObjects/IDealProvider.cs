using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BusinessObjects
{
    public interface IDealProvider
    {
        string Name { get; set; }
        string URL { get; set; }
        DateTime LastModified { get; set; }

        IDealResponse GetDeals(IDealRequest request);
    }
}
