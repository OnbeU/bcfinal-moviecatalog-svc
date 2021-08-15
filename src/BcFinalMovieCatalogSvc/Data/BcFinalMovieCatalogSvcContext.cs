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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CatalogItem>().OwnsOne(x => x.MovieMetadata);
        }
    }
}
