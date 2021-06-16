using Icxl.Abp.Ids.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Icxl.Abp.Ids.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(IdsEntityFrameworkCoreDbMigrationsModule),
        typeof(IdsApplicationContractsModule)
        )]
    public class IdsDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
