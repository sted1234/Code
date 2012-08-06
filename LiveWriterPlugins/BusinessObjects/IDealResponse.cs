using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects
{
    public interface IDealResponse
    {
        IEnumerable<DealItem> DealItems { get; set; }
    }
}
