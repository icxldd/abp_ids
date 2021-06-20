using System.Threading.Tasks;
using Icxl.Abp.ChurchSetting.Localization;
using Icxl.Abp.Ids.Localization;
using Microsoft.Extensions.Localization;
using Volo.Abp.Application.Services;

namespace Icxl.Abp.ChurchSetting.Application
{
    public class SampleTestAppService : ApplicationService
    {
        private readonly IStringLocalizer<SettingResource> _localizer;
        private readonly IStringLocalizer<IdsResource> _idsLocalizer;

        public SampleTestAppService(
            IStringLocalizer<SettingResource> localizer,
            IStringLocalizer<IdsResource> idsLocalizer
        )
        {
            _localizer = localizer;
            _idsLocalizer = idsLocalizer;
        }

        public async Task<string> GetDataAsync()
        {
            var str = _localizer["ChurchSetting_Test"] + "----" + _idsLocalizer["icxl"];
            return await Task.FromResult(str);
        }
    }
}