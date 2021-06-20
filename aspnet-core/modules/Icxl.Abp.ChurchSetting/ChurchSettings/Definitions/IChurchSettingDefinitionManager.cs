using System.Collections.Generic;
using JetBrains.Annotations;

namespace Icxl.Abp.ChurchSetting.ChurchSettings.Definitions
{
    public interface IChurchSettingDefinitionManager
    {
        ChurchSettingDefinition Get([NotNull] string name);

        IReadOnlyList<ChurchSettingDefinition> GetAll();

        ChurchSettingDefinition GetOrNull(string name);
    }
}