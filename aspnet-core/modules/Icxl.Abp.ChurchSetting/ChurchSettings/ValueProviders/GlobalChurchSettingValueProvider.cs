using System;
using System.Threading.Tasks;
using Icxl.Abp.ChurchSetting.ChurchSettings.Definitions;
using Volo.Abp.Domain.Repositories;

namespace Icxl.Abp.ChurchSetting.ChurchSettings.ValueProviders
{
    /// <summary>
    /// 全局提供者方式查找
    /// </summary>
    public class GlobalChurchSettingValueProvider : ChurchSettingValueProvider
    {
      
        public GlobalChurchSettingValueProvider(IRepository<Domain.ChurchSetting, Guid> churchSettingRepository, ICurrentChurch currentChurch) : base(churchSettingRepository, currentChurch)
        {
        }
        public override string ProviderName => "G";


        public override async Task<Guid?> GetOrNullAsync(ChurchSettingDefinition churchSetting)
        {
            var dbEntity = await ChurchSettingRepository
                .FirstOrDefaultAsync(x =>
                    x.ProviderName == ProviderName
                    && x.ChurchSettingName == churchSetting.Name
                    && x.Enable);

            return dbEntity?.Id;
        }

      
    }
}