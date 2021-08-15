using System;
using System.Collections.Generic;
using System.Linq;

namespace BcFinalMovieCatalogSvc.Features.DataSeeding
{
    public static class Assets
    {
        public static IEnumerable<Seed> GetMovieMetadataSeeds()
        {
            var manifestResourceNames = typeof(Assets).Assembly.GetManifestResourceNames(); // e.g. "DiiLegacy.Data.Assets.MovieMetadata.tt1520211.json", ...
            for (long i = 0; i < manifestResourceNames.Count(); i++)
            {
                byte[] guidData = new byte[16];
                Array.Copy(BitConverter.GetBytes(i+1), guidData, 8);
                var guid = new Guid(guidData);

                yield return new Seed(guid, manifestResourceNames[i]);
            }
        }
    }
}
