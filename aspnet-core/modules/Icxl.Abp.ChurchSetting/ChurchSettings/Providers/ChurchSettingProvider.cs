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
        protected IChurchSettingDefinitionManager _churchSettingDefinitionManager { get; }
        protected IChurchSettingValueProviderManager _churchSettingValueProviderManager { get; }

        public ChurchSettingProvider(
            IChurchSettingDefinitionManager ChurchSettingDefinitionManager,
            IChurchSettingValueProviderManager ChurchSettingValueProviderManager
        )
        {
            _churchSettingDefinitionManager = ChurchSettingDefinitionManager;
            _churchSettingValueProviderManager = ChurchSettingValueProviderManager;
        }


        public virtual async Task<Guid?> GetOrNullAsync(string definitionName, string churchSettingName)
        {
            var ChurchSetting = _churchSettingDefinitionManager.Get(definitionName);

            var providers = Enumerable
                .Reverse(_churchSettingValueProviderManager.Providers);

            if (ChurchSetting.Providers.Any())
            {
                providers = providers.Where(p => ChurchSetting.Providers.Contains(p.ProviderName));
            }

            var value = await GetOrNullValueFromProvidersAsync(providers, churchSettingName);
            return value;
        }

        protected virtual async Task<Guid?> GetOrNullValueFromProvidersAsync(
            IEnumerable<IChurchSettingValueProvider> providers,
            string churchSettingName)
        {
            foreach (var provider in providers)
            {
                var value = await provider.GetOrNullAsync(churchSettingName);
                if (value != null)
                {
                    return value;
                }
            }

            return null;
        }
    }
}