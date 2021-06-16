using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Icxl.Abp.Ids.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class IdsMigrationsDbContextFactory : IDesignTimeDbContextFactory<IdsMigrationsDbContext>
    {
        public IdsMigrationsDbContext CreateDbContext(string[] args)
        {
            IdsEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<IdsMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new IdsMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Icxl.Abp.Ids.DbMigrator/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
