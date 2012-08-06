using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects
{
    public interface IDealRequest
    {
        string Name { get; set; }
        string Url { get; set; }
    }
}
