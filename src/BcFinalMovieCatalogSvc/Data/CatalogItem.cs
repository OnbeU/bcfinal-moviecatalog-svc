using System;

namespace BcFinalMovieCatalogSvc.Data
{
    public class CatalogItem
    {
        public Guid Id { get; set; }

        public MovieMetadata MovieMetadata { get; set; }
    }
}
