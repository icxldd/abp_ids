using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Icxl.Abp.ChurchSetting.ChurchSettings.Definitions;
using Icxl.Abp.ChurchSetting.ChurchSettings.Providers;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Services;

namespace Icxl.Abp.ChurchSetting.Application
{
    public class ChurchSettingRequestInput
    {
        public string DefinitionName { get; set; }

        public string ChurchSettingName { get; set; }
    }

    public interface IChurchSettingManagementAppService : IApplicationService
    {
        Task<IReadOnlyList<ChurchSettingDefinition>> GetAllDefineAsync();
        Task<Guid?> GetAsync(ChurchSettingRequestInput input);
    }

    public class ChurchSettingManagementAppService :
        ApplicationService,
        IChurchSettingManagementAppService
    {
        private readonly IChurchSettingDefinitionManager _ChurchSettingDefinitionManager;
        private readonly IChurchSettingProvider _ChurchSettingProvider;

        public ChurchSettingManagementAppService(
            IChurchSettingDefinitionManager ChurchSettingDefinitionManager,
            IChurchSettingProvider ChurchSettingProvider
        )
        {
            _ChurchSettingDefinitionManager = ChurchSettingDefinitionManager;
            _ChurchSettingProvider = ChurchSettingProvider;
        }

        public async Task<IReadOnlyList<ChurchSettingDefinition>> GetAllDefineAsync()
        {
            return await Task.FromResult(_ChurchSettingDefinitionManager.GetAll());
        }

        public async Task<Guid?> GetAsync(ChurchSettingRequestInput input)
        {
            return await _ChurchSettingProvider.GetOrNullAsync(input.DefinitionName, input.ChurchSettingName);
        }
    }
}