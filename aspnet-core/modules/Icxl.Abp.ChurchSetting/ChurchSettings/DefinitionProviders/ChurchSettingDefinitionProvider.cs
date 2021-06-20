using Icxl.Abp.ChurchSetting.ChurchSettings.Definitions;
using Volo.Abp.DependencyInjection;

namespace Icxl.Abp.ChurchSetting.ChurchSettings.DefinitionProviders
{
    /// <summary>
    /// 定义
    /// </summary>
    public abstract class ChurchSettingDefinitionProvider : IChurchSettingDefinitionProvider, ITransientDependency
    {
        public abstract void Define(IChurchSettingDefinitionContext context);
    }
}