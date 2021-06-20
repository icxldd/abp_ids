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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="churchSettingName"></param>
        /// <returns></returns>
        Task<Guid?> GetOrNullAsync([NotNull] string churchSettingName);
    }
}