using Icxl.Abp.ChurchSetting;
using Volo.Abp.Modularity;

namespace Icxl.Abp.Ids
{
    [DependsOn(
        typeof(IdsApplicationModule),
        typeof(IdsDomainTestModule)
    )]
    public class IdsApplicationTestModule : AbpModule
    {
    }
}