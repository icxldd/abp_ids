using System;
using System.Collections.Generic;
using Shouldly;
using System.Threading.Tasks;
using Icxl.Abp.ChurchSetting;
using Icxl.Abp.ChurchSetting.Application;
using Icxl.Abp.ChurchSetting.Application.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;
using Xunit;

namespace Icxl.Abp.Ids.Samples
{
    /* This is just an example test class.
     * Normally, you don't test code of the modules you are using
     * (like IIdentityUserAppService here).
     * Only test your own application services.
     */
    public class SampleAppServiceTests : IdsApplicationTestBase
    {
        private readonly IIdentityUserAppService _userAppService;
        private readonly IChurchSettingAppService _churchSettingAppService;

        public SampleAppServiceTests()
        {
            _userAppService = GetRequiredService<IIdentityUserAppService>();
            _churchSettingAppService = GetRequiredService<IChurchSettingAppService>();
        }

        [Fact]
        public async Task Initial_Data_Should_Contain_Admin_User()
        {
            //Act
            var result = await _userAppService.GetListAsync(new GetIdentityUsersInput());

            //Assert
            result.TotalCount.ShouldBeGreaterThan(0);
            result.Items.ShouldContain(u => u.UserName == "admin");
        }

        private async Task<Guid> insert()
        {
            Guid id = Guid.NewGuid();
            List<ChurchSettingNodeCreateOrEditDto> listNode = new List<ChurchSettingNodeCreateOrEditDto>();
            ChurchSettingNodeCreateOrEditDto node = new ChurchSettingNodeCreateOrEditDto()
            {
                ChurchSettingId = id,
                Value = "bool"
            };
            listNode.Add(node);
            var createDto = new ChurchSettingCreateOrEditDto()
            {
                Id = id, ChurchSettingName = "isVip", Enable = true, ProviderName = "U", ProviderKey = "123456",
                ChurchSettingNodes = listNode
            };
            await _churchSettingAppService.CreateAsync(createDto);
            return id;
        }
        private async Task<Guid> insert2()
        {
            Guid id = Guid.NewGuid();
            List<ChurchSettingNodeCreateOrEditDto> listNode = new List<ChurchSettingNodeCreateOrEditDto>();
            ChurchSettingNodeCreateOrEditDto node = new ChurchSettingNodeCreateOrEditDto()
            {
                ChurchSettingId = id,
                Value = "123456668"
            };
            listNode.Add(node);
            var createDto = new ChurchSettingCreateOrEditDto()
            {
                Id = id, ChurchSettingName = "isVip", Enable = false, ProviderName = "Guild", ProviderKey = "10000",
                ChurchSettingNodes = listNode
            };
            await _churchSettingAppService.CreateAsync(createDto);
            return id;
        }
        [Fact]
        public async Task Test_ChurchSetting()
        {
            var id1 = await insert();
            var id2 = await insert2();
            var dto = await _churchSettingAppService.GetForEdit(id2);
            var provider = await _churchSettingAppService.GetByProvider(new GetChurchSettingDto()
            {
                DefinitionName = ChurchSettingConst.Test,
                ChurchSettingName = "isVip"
            });
            // GetByProvider
            var result = await _churchSettingAppService.GetListAsync(new PagedResultRequestDto() { });
        }
    }
}