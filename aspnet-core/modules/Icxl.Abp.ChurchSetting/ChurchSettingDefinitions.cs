using Icxl.Abp.ChurchSetting.ChurchSettings.DefinitionProviders;
using Icxl.Abp.ChurchSetting.ChurchSettings.Definitions;
using Icxl.Abp.ChurchSetting.Localization;
using Volo.Abp.Localization;

namespace Icxl.Abp.ChurchSetting
{
    public class ChurchSettingDefinitions: ChurchSettingDefinitionProvider
    {
        public override void Define(IChurchSettingDefinitionContext context)
        {
            context.Add(
                new ChurchSettingDefinition(ChurchSettingConst.Test, L("ChurchSetting_Test")).WithProviders("G", "U", "Guild")
            );
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<SettingResource>(name);
        }
    }
    
    public static class ChurchSettingConst
    {
        private const string GroupName = "ChurchSetting_";
        public const string Test = GroupName + "Test";
    }
}