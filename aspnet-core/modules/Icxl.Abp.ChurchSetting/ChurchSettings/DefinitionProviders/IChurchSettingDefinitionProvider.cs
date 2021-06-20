using Icxl.Abp.ChurchSetting.ChurchSettings.Definitions;

namespace Icxl.Abp.ChurchSetting.ChurchSettings.DefinitionProviders
{
    public interface IChurchSettingDefinitionProvider
    {
        void Define(IChurchSettingDefinitionContext context);
    }
}