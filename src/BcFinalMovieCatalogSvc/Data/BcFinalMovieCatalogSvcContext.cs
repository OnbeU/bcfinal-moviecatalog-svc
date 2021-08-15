using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BcFinalMovieCatalogSvc.Data
{
    public class BcFinalMovieCatalogSvcContext : DbContext
    {
        public BcFinalMovieCatalogSvcContext (DbContextOptions<BcFinalMovieCatalogSvcContext> options)
            : base(options)
        {
        }

        public DbSet<BcFinalMovieCatalogSvc.Data.CatalogItem> CatalogItem { get; set; }
    }
}
