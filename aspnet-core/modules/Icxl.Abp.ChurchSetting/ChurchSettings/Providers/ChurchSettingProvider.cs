using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Icxl.Abp.ChurchSetting.ChurchSettings.Definitions;
using Icxl.Abp.ChurchSetting.ChurchSettings.ValueProviders;
using Volo.Abp.DependencyInjection;

namespace Icxl.Abp.ChurchSetting.ChurchSettings.Providers
{
    public class ChurchSettingProvider : IChurchSettingProvider, ITransientDependency
    {
        protected IChurchSettingDefinitionManager ChurchSettingDefinitionManager { get; }
        protected IChurchSettingValueProviderManager ChurchSettingValueProviderManager { get; }

        public ChurchSettingProvider(
            IChurchSettingDefinitionManager ChurchSettingDefinitionManager,
            IChurchSettingValueProviderManager ChurchSettingValueProviderManager
        )
        {
            ChurchSettingDefinitionManager = ChurchSettingDefinitionManager;
            ChurchSettingValueProviderManager = ChurchSettingValueProviderManager;
        }


        public virtual async Task<Guid?> GetOrNullAsync(string name)
        {
            var ChurchSetting = ChurchSettingDefinitionManager.Get(name);

            var providers = Enumerable
                .Reverse(ChurchSettingValueProviderManager.Providers);

            if (ChurchSetting.Providers.Any())
            {
                providers = providers.Where(p => ChurchSetting.Providers.Contains(p.ProviderName));
            }

            var value = await GetOrNullValueFromProvidersAsync(providers, ChurchSetting);
            return value;
        }

        protected virtual async Task<Guid?> GetOrNullValueFromProvidersAsync(
            IEnumerable<IChurchSettingValueProvider> providers,
            ChurchSettingDefinition ChurchSetting)
        {
            foreach (var provider in providers)
            {
                var value = await provider.GetOrNullAsync(ChurchSetting);
                if (value != null)
                {
                    return value;
                }
            }

            return null;
        }
    }
}