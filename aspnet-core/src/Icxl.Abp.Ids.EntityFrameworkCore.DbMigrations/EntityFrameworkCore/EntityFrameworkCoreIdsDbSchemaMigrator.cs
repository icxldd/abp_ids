using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Icxl.Abp.Ids.Data;
using Volo.Abp.DependencyInjection;

namespace Icxl.Abp.Ids.EntityFrameworkCore
{
    public class EntityFrameworkCoreIdsDbSchemaMigrator
        : IIdsDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreIdsDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the IdsMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<IdsMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}