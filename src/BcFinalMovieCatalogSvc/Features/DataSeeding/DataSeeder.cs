using BcFinalMovieCatalogSvc.Data;
using System.Collections.Generic;
using System.IO;
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
                string json = GetJsonAsset(seed.assetName);
                var movieMetadata = MovieMetadata.FromJson(json);
                var catalogItem = new CatalogItem()
                {
                    Id = seed.id,
                    MovieMetadata = movieMetadata,
                };
                _context.CatalogItem.Add(catalogItem);
            }
            _context.SaveChanges();
        }

        public string GetJsonAsset(string assetName)
        {
            using Stream stream = typeof(DataSeeder).Assembly.GetManifestResourceStream(assetName);
            using StreamReader sr = new StreamReader(stream);
            string content = sr.ReadToEnd();
            return content;
        }
    }
}
