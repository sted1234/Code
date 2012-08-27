using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sandworks.Google.Reader;
using System.Xml.Linq;
using System.Configuration;

namespace SearchDeals.Models
{
    public class DealsRepository : IDealsRepository
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string  Source { get; set; }

        private int defaultDealCount;
        public int DefaultDealCount 
        { 
            get
            {
                return defaultDealCount;
            }
            set
            {
                defaultDealCount = value;
            }
        }

        public DealsRepository()
        {
            string username = Properties.EncryptedSettings.Default.GMailUserName;
            string password = Properties.EncryptedSettings.Default.GMailPassword;
            string source = Properties.EncryptedSettings.Default.GMailSource;

            UserName = username;
            Password = password;
            Source = source;
            DefaultDealCount = Properties.EncryptedSettings.Default.DefaultDealCount;
        }

        public IEnumerable<RawDealItem> GetDeals(string product)
        {
            return GetDeals(product, DefaultDealCount);
        }


        public IEnumerable<RawDealItem> GetDeals(string product, int count)
        {
            List<RawDealItem> results = new List<RawDealItem>();
            using (ReaderService rdr = new ReaderService(UserName, Password, Source))
            {
                var resultsXml = rdr.Search(product, (count * 2).ToString());
                XNamespace xmlns = "http://www.w3.org/2005/Atom";
                if(!string.IsNullOrWhiteSpace(resultsXml))
                    results = XElement.Parse(resultsXml).Elements(xmlns + "entry").Select(o => new RawDealItem(o, xmlns)).ToList<RawDealItem>();
            }
            return results.Distinct<RawDealItem>(new DealItemComparer()).Take(count);
        }
    }


}