using System;
using System.Threading.Tasks;

namespace Icxl.Abp.ChurchSetting.ChurchSettings.Providers
{
    public interface IChurchSettingProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="definitionName">定义的name</param>
        /// <returns></returns>
        Task<Guid?> GetOrNullAsync(string definitionName, string churchSettingName);
    }
}