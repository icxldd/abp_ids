using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Icxl.Abp.ChurchSetting.ChurchSettings.DefinitionProviders;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Volo.Abp;
using Volo.Abp.DependencyInjection;

namespace Icxl.Abp.ChurchSetting.ChurchSettings.Definitions
{
    public class ChurchSettingDefinitionManager
        : IChurchSettingDefinitionManager, ISingletonDependency
    {
        protected Lazy<IDictionary<string, ChurchSettingDefinition>> ChurchSettingDefinitions { get; }

        protected ChurchSettingOptions Options { get; }

        protected IServiceProvider ServiceProvider { get; }


        public ChurchSettingDefinitionManager(IOptions<ChurchSettingOptions> options, IServiceProvider serviceProvider)
        {
            Options = options.Value;
            ServiceProvider = serviceProvider;

            ChurchSettingDefinitions = new Lazy<IDictionary<string, ChurchSettingDefinition>>(CreateChurchSettingDefinitions, true);
        }

        public ChurchSettingDefinition Get(string name)
        {
            Check.NotNull(name, nameof(name));

            var ChurchSetting = GetOrNull(name);

            if (ChurchSetting == null)
            {
                throw new AbpException("Undefined setting: " + name);
            }

            return ChurchSetting;
        }

        public IReadOnlyList<ChurchSettingDefinition> GetAll()
        {
            return ChurchSettingDefinitions.Value.Values.ToImmutableList();
        }

        public ChurchSettingDefinition GetOrNull(string name)
        {
            return ChurchSettingDefinitions.Value.GetOrDefault(name);
        }

        protected virtual IDictionary<string, ChurchSettingDefinition> CreateChurchSettingDefinitions()
        {
            var ChurchSettings = new Dictionary<string, ChurchSettingDefinition>();

            using var scope = ServiceProvider.CreateScope();
            var providers = Options
                .DefinitionProviders
                .Select(p => scope.ServiceProvider.GetRequiredService(p) as IChurchSettingDefinitionProvider)
                .ToList();

            foreach (var provider in providers)
            {
                provider.Define(new ChurchSettingDefinitionContext(ChurchSettings));
            }

            return ChurchSettings;
        }
    }
}