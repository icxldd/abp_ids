using Icxl.Abp.Ids.Authorize;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace Icxl.Abp.Ids
{
    [DependsOn(
        typeof(IdsDomainModule),
        typeof(AbpAccountApplicationModule),
        typeof(IdsApplicationContractsModule),
        typeof(AbpIdentityApplicationModule),
        typeof(AbpPermissionManagementApplicationModule),
        typeof(AbpTenantManagementApplicationModule),
        typeof(AbpFeatureManagementApplicationModule),
        typeof(AbpSettingManagementApplicationModule)
    )]
    public class IdsApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddIdentityServerBuilder().AddExtensionGrantValidator<SMSGrantValidator>();
            Configure<AbpAutoMapperOptions>(options => { options.AddMaps<IdsApplicationModule>(); });
        }
    }
}