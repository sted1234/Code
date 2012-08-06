using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchDeals.Models
{
    public class DealsProcessor : IDealsProcessor
    {

        IDealsRepository dealsRepository;

        public DealsProcessor(IDealsRepository dealsRepository)
        {
            this.dealsRepository = dealsRepository;
        }

        public IEnumerable<DealItem> GetDeals(string product)
        {
            IEnumerable<RawDealItem> deals = dealsRepository.GetDeals(product);
            var x = from deal in deals
                    select new DealItem
                    {
                        Author = deal.Author,
                        Categories = deal.Categories,
                        Published = deal.Published,
                        Source = deal.Source,
                        SourceUrl = deal.SourceUrl,
                        Summary = deal.Summary,
                        Title = deal.Title,
                        Updated = deal.Updated,
                        Url = deal.Url,
                        XmlNamespace = deal.XmlNamespace
                    };
            return x;

        }

        public IEnumerable<DealItem> GetDeals(string product, int count)
        {
            IEnumerable<RawDealItem> deals = dealsRepository.GetDeals(product, count);
            var x = from deal in deals
                    select new DealItem
                    {
                        Author = deal.Author,
                        Categories = deal.Categories,
                        Published = deal.Published,
                        Source = deal.Source,
                        SourceUrl = deal.SourceUrl,
                        Summary = deal.Summary,
                        Title = deal.Title,
                        Updated = deal.Updated,
                        Url = deal.Url,
                        XmlNamespace = deal.XmlNamespace
                    };
            return x;
        }
    }
}