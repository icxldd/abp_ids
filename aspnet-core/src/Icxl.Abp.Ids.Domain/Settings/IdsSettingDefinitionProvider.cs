using Volo.Abp.Settings;

namespace Icxl.Abp.Ids.Settings
{
    public class IdsSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(IdsSettings.MySetting1));
        }
    }
}
