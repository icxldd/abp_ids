namespace Icxl.Abp.ChurchSetting.ChurchSettings.Definitions
{
    public interface IChurchSettingDefinitionContext
    {
        ChurchSettingDefinition GetOrNull(string name);

        void Add(params ChurchSettingDefinition[] definitions);
    }
}