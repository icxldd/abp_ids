using System;
using System.Threading.Tasks;
using Icxl.Abp.ChurchSetting.ChurchSettings.Definitions;
using Volo.Abp.Domain.Repositories;

namespace Icxl.Abp.ChurchSetting.ChurchSettings.ValueProviders
{
    /// <summary>
    /// 用户提供者
    /// </summary>
    public class UserChurchSettingValueProvider : ChurchSettingValueProvider
    {
        public UserChurchSettingValueProvider(IRepository<Domain.ChurchSetting, Guid> churchSettingRepository,
            ICurrentChurch currentChurch) : base(churchSettingRepository, currentChurch)
        {
        }

        public override string ProviderName => "U";

        public override async Task<Guid?> GetOrNullAsync(ChurchSettingDefinition churchSetting)
        {
            if (_currentChurch.UserId == null)
            {
                return null;
            }

            var dbEntity = await ChurchSettingRepository
                .FirstOrDefaultAsync(x =>
                    x.ChurchSettingName == churchSetting.Name &&
                    x.ProviderName == ProviderName &&
                    x.ProviderKey == _currentChurch.UserId
                    && x.Enable);

            return dbEntity?.Id;
        }
    }
}