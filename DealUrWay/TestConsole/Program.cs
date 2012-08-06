using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ServiceModel.Syndication;
using System.Xml;


using System.Reflection;
using DealUrWay.DealManager;
using DealUrWay.BusinessObjects;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            DealRequest request = new DealRequest{Name="SlickDeals"};
            IDealResponse response = DealManager.GetDeals(request);
            IEnumerable<string> dealProviders = DealManager.GetDealProviders();

            foreach (string s in dealProviders)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine(response.DealItems.Count());


            request.Name = "FatWallet";
            response = DealManager.GetDeals(request);
            Console.WriteLine(response.DealItems.Count());

            Console.Read();
        }

    }
}
    