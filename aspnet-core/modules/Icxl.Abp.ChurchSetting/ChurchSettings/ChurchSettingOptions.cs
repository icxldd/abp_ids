using Icxl.Abp.ChurchSetting.ChurchSettings.DefinitionProviders;
using Icxl.Abp.ChurchSetting.ChurchSettings.ValueProviders;
using Volo.Abp.Collections;

namespace Icxl.Abp.ChurchSetting.ChurchSettings
{
    public class ChurchSettingOptions
    {
        public ITypeList<IChurchSettingDefinitionProvider> DefinitionProviders { get; }

        public ITypeList<IChurchSettingValueProvider> ValueProviders { get; }

        public ChurchSettingOptions()
        {
            DefinitionProviders = new TypeList<IChurchSettingDefinitionProvider>();
            ValueProviders = new TypeList<IChurchSettingValueProvider>();
        }
    }
}