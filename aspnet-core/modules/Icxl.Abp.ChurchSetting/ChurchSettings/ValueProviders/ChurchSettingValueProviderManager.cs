using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Volo.Abp.DependencyInjection;

namespace Icxl.Abp.ChurchSetting.ChurchSettings.ValueProviders
{
    public class ChurchSettingValueProviderManager : IChurchSettingValueProviderManager, ISingletonDependency
    {
        public List<IChurchSettingValueProvider> Providers => _lazyProviders.Value;
        protected ChurchSettingOptions Options { get; }

        private readonly Lazy<List<IChurchSettingValueProvider>> _lazyProviders;

        public ChurchSettingValueProviderManager(
            IServiceProvider serviceProvider,
            IOptions<ChurchSettingOptions> options)
        {
            Options = options.Value;

            _lazyProviders = new Lazy<List<IChurchSettingValueProvider>>(
                () => Options
                    .ValueProviders
                    .Select(type => serviceProvider.GetRequiredService(type) as IChurchSettingValueProvider)
                    .ToList(),
                true
            );
        }
    }
}