using System.Collections.Generic;

namespace Icxl.Abp.ChurchSetting.ChurchSettings.ValueProviders
{
    public interface IChurchSettingValueProviderManager
    {
        List<IChurchSettingValueProvider> Providers { get; }
    }
}