using System.Collections.Generic;
using System.Collections.Immutable;

namespace Icxl.Abp.ChurchSetting.ChurchSettings.Definitions
{
    public class ChurchSettingDefinitionContext : IChurchSettingDefinitionContext
    {
        protected Dictionary<string, ChurchSettingDefinition> ChurchSettings { get; }

        public ChurchSettingDefinitionContext(Dictionary<string, ChurchSettingDefinition> _churchSettings)
        {
            ChurchSettings = _churchSettings;
        }

        public virtual ChurchSettingDefinition GetOrNull(string name)
        {
            return ChurchSettings.GetOrDefault(name);
        }

        public virtual IReadOnlyList<ChurchSettingDefinition> GetAll()
        {
            return ChurchSettings.Values.ToImmutableList();
        }

        public virtual void Add(params ChurchSettingDefinition[] definitions)
        {
            if (definitions.IsNullOrEmpty())
            {
                return;
            }

            foreach (var definition in definitions)
            {
                ChurchSettings[definition.Name] = definition;
            }
        }
    }
}