using BcFinalMovieCatalogSvc.Data;
using BcFinalMovieCatalogSvc.Features.DataSeeding;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;
using Xunit;

namespace BcFinalMovieCatalogSvcTests.Features.DataSeeding
{
    public class DataSeederTests
    {
        [Fact]
        public void ShouldRun_WhenEmptyDatabase_ReturnsTrue()
        {
            // Arrange
            var builder = new DbContextOptionsBuilder<BcFinalMovieCatalogSvcContext>();
            string uniqueEnoughName = $"{nameof(BcFinalMovieCatalogSvcContext)}_{MethodBase.GetCurrentMethod().Name}";
            builder.UseInMemoryDatabase(databaseName: uniqueEnoughName);

            var dbContextOptions = builder.Options;
            var context = new BcFinalMovieCatalogSvcContext(dbContextOptions);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var seeder = new DataSeeder(context, seeds: null);

            // Act
            bool result = seeder.ShouldRun();

            // Assert
            result.Should().BeTrue("because the context is empty");
        }

        [Fact]
        public void SeedIt_CreatesStuff()
        {
            // Arrange
            var seeds = Assets.GetMovieMetadataSeeds();

            var builder = new DbContextOptionsBuilder<BcFinalMovieCatalogSvcContext>();
            string uniqueEnoughName = $"{nameof(BcFinalMovieCatalogSvcContext)}_{MethodBase.GetCurrentMethod().Name}";
            builder.UseInMemoryDatabase(databaseName: uniqueEnoughName);

            var dbContextOptions = builder.Options;
            var context = new BcFinalMovieCatalogSvcContext(dbContextOptions);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var seeder = new DataSeeder(context, seeds);

            // Act
            seeder.SeedIt();

            // Assert
            context.CatalogItem.Count().Should().Be(12);
        }
    }
}
