using System;
using System.Threading.Tasks;
using Icxl.Abp.ChurchSetting.ChurchSettings.Definitions;
using Volo.Abp.Domain.Repositories;

namespace Icxl.Abp.ChurchSetting.ChurchSettings.ValueProviders
{
    /// <summary>
    /// 教会提供者
    /// </summary>
    public class GuildChurchSettingValueProvider : ChurchSettingValueProvider
    {
        public GuildChurchSettingValueProvider(IRepository<Domain.ChurchSetting, Guid> churchSettingRepository,
            ICurrentChurch currentChurch) : base(churchSettingRepository, currentChurch)
        {
        }

        public override string ProviderName => "Guild";

        public override async Task<Guid?> GetOrNullAsync(ChurchSettingDefinition churchSetting)
        {
            if (_currentChurch.GuildId == null)
            {
                return null;
            }

            var dbEntity = await ChurchSettingRepository
                .FirstOrDefaultAsync(x =>
                    x.ChurchSettingName == churchSetting.Name &&
                    x.ProviderName == ProviderName &&
                    x.ProviderKey == _currentChurch.GuildId
                    && x.Enable);

            return dbEntity?.Id;
        }
    }
}