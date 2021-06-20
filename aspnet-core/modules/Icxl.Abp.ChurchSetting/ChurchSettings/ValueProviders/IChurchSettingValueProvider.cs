using System;
using System.Threading.Tasks;
using Icxl.Abp.ChurchSetting.ChurchSettings.Definitions;
using JetBrains.Annotations;

namespace Icxl.Abp.ChurchSetting.ChurchSettings.ValueProviders
{
    /// <summary>
    /// 提供者
    /// </summary>
    public interface IChurchSettingValueProvider
    {
        string ProviderName { get; }

        Task<Guid?> GetOrNullAsync([NotNull] ChurchSettingDefinition churchSetting);
    }
}