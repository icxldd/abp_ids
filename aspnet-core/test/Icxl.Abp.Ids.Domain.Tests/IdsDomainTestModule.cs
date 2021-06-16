using Icxl.Abp.Ids.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Icxl.Abp.Ids
{
    [DependsOn(
        typeof(IdsEntityFrameworkCoreTestModule)
        )]
    public class IdsDomainTestModule : AbpModule
    {

    }
}