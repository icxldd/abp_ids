using System;
using System.Collections.Generic;
using Icxl.Abp.ChurchSetting.ChurchSettings;
using Icxl.Abp.ChurchSetting.ChurchSettings.DefinitionProviders;
using Icxl.Abp.ChurchSetting.ChurchSettings.ValueProviders;
using Icxl.Abp.ChurchSetting.EntityFrameworkCore;
using Icxl.Abp.ChurchSetting.Localization;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AutoMapper;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace Icxl.Abp.ChurchSetting
{
    [DependsOn(
        typeof(AbpAspNetCoreMvcModule),
        typeof(AbpAutoMapperModule),
        typeof(AbpValidationModule)
    )]
    public class ChurchSettingModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            AutoAddDefinitionProviders(context.Services);
        }

        private static void AutoAddDefinitionProviders(IServiceCollection services)
        {
            var definitionProviders = new List<Type>();

            services.OnRegistred(context =>
            {
                if (typeof(IChurchSettingDefinitionProvider).IsAssignableFrom(context.ImplementationType))
                {
                    definitionProviders.Add(context.ImplementationType);
                }
            });
            services.Configure<ChurchSettingOptions>(options =>
            {
                options.DefinitionProviders.AddIfNotContains(definitionProviders);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            ConfigureLocalization();


            context.Services.AddAbpDbContext<ChurchSettingDbContext>(options =>
            {
                options.AddDefaultRepositories(true);
            });

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<ChurchSettingAutoMapperProfile>(validate: false);
            });

            context.Services.AddAutoMapperObjectMapper<ChurchSettingModule>();

            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.MinifyGeneratedScript = true;
                options.ConventionalControllers.Create(typeof(ChurchSettingModule).Assembly,
                    opts => { opts.RootPath = "church-setting"; });
            });


            Configure<ChurchSettingOptions>(options =>
            {
                options.ValueProviders.Add<GlobalChurchSettingValueProvider>();
                options.ValueProviders.Add<UserChurchSettingValueProvider>();
                options.ValueProviders.Add<GuildChurchSettingValueProvider>();
            });
        }

        private void ConfigureLocalization()
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<ChurchSettingModule>("Icxl.Abp.ChurchSetting");
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<SettingResource>("zh-Hans")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("/Localization/Setting");
            });
        }
    }
}