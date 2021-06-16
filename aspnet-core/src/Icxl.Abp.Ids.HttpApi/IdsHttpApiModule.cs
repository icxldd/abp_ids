using Localization.Resources.AbpUi;
using Icxl.Abp.Ids.Localization;
using Volo.Abp.Account;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.HttpApi;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace Icxl.Abp.Ids
{
    [DependsOn(
        typeof(IdsApplicationContractsModule),
        typeof(AbpAccountHttpApiModule),
        typeof(AbpIdentityHttpApiModule),
        typeof(AbpPermissionManagementHttpApiModule),
        typeof(AbpTenantManagementHttpApiModule),
        typeof(AbpFeatureManagementHttpApiModule),
        typeof(AbpSettingManagementHttpApiModule)
    )]
    public class IdsHttpApiModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            ConfigureLocalization();


            // Configure<AbpAspNetCoreMvcOptions>(options =>
            // {
            //     options.MinifyGeneratedScript = true;
            //     options
            //         .ConventionalControllers
            //         .Create(typeof(IdsApplicationModule).Assembly, opts =>
            //         {
            //             opts.RootPath = "icxl";
            //             opts.RemoteServiceName = "Icxl";
            //         });
            // });
        }

        private void ConfigureLocalization()
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<IdsResource>()
                    .AddBaseTypes(
                        typeof(AbpUiResource)
                    );
            });
        }
    }
}