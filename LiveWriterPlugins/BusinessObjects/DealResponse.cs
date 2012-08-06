using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects
{
    public class DealResponse : IDealResponse
    {
        IEnumerable<DealItem> dealItems;

        public IEnumerable<DealItem> DealItems
        {

            get
            {
                return dealItems;        
            }
            set
            {
                dealItems = value;
            }
        }
    }
}
