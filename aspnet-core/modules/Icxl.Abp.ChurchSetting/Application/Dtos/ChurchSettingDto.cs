using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Icxl.Abp.ChurchSetting.Application.Dtos
{
    public class ChurchSettingDto: CreationAuditedEntityDto<Guid>
    {
        public string ChurchSettingName { get;private set; }
        public bool Enable { get; set; }
        public string ProviderName { get; set; }
        public string ProviderKey { get; set; }

        public List<ChurchSettingNodeDto> ChurchSettingNodes { get; set; }
    }
}