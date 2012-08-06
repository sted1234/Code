using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Net4ToNet2Adapter
{
    [ComVisible(true)]
    [Guid("E36BBF07-591E-4959-97AE-D439CBA392FB")]
    public interface IGoogleReaderAdapter
    {
        StringBuilder GetHTML(string feedUrl, string username, string password);
    }


        

}
