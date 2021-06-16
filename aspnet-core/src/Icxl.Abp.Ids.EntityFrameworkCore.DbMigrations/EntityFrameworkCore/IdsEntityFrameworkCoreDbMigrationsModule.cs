using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Icxl.Abp.Ids.EntityFrameworkCore
{
    [DependsOn(
        typeof(IdsEntityFrameworkCoreModule)
        )]
    public class IdsEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<IdsMigrationsDbContext>();
        }
    }
}
