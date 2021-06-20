using System;
using Volo.Abp.Application.Dtos;

namespace Icxl.Abp.ChurchSetting.Application.Dtos
{
    public class ChurchSettingNodeDto : CreationAuditedEntityDto<Guid>
    {
        public string Desc { get; set; }
        public string Value { get; set; }
        public Guid ChurchSettingId { get; set; }
    }
}