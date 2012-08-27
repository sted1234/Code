using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sandworks.Google.Reader;


namespace AlvinAshcraftLinks
{
    public class ReaderTest
    {
        public static void Main(string[] args)
        {
            using (ReaderService rdr = new ReaderService("username", "password", "Sandworks.Google.App"))
            {
                var o = rdr.Search("Sony Hdtv", "100");
                Console.WriteLine(o);
            }

            Console.Read();

        }
    }
}
