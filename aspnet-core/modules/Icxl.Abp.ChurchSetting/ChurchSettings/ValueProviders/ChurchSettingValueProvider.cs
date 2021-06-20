using System;
using System.Threading.Tasks;
using Icxl.Abp.ChurchSetting.ChurchSettings.Definitions;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Icxl.Abp.ChurchSetting.ChurchSettings.ValueProviders
{
    public abstract class ChurchSettingValueProvider : IChurchSettingValueProvider, ITransientDependency
    {
        protected readonly ICurrentChurch _currentChurch;
        protected IRepository<Domain.ChurchSetting, Guid> ChurchSettingRepository { get; }
        public abstract string ProviderName { get; }

        protected ChurchSettingValueProvider(IRepository<Domain.ChurchSetting, Guid> churchSettingRepository,
            ICurrentChurch currentChurch)
        {
            _currentChurch = currentChurch;
            ChurchSettingRepository = churchSettingRepository;
        }

        public abstract Task<Guid?> GetOrNullAsync(string churchSettingName);
    }
}