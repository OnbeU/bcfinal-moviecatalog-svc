using BcFinalMovieCatalogSvc.Data;
using System.Collections.Generic;
using System.Linq;

namespace BcFinalMovieCatalogSvc.Features.DataSeeding
{
    public class DataSeeder
    {
        private readonly BcFinalMovieCatalogSvcContext _context;
        private readonly IEnumerable<Seed> _seeds;

        public DataSeeder(
            BcFinalMovieCatalogSvcContext context,
            IEnumerable<Seed> seeds)
        {
            _context = context;
            _seeds = seeds;
        }

        public bool ShouldRun()
        {
            return !_context.CatalogItem.Any();
        }

        public void SeedIt()
        {
            foreach(var seed in _seeds)
            {
                var catalogItem = new CatalogItem()
                {
                    Id = seed.id,
                    DummyProperty = seed.assetName
                };
                _context.CatalogItem.Add(catalogItem);
                _context.SaveChanges();
            }
        }
    }
}
