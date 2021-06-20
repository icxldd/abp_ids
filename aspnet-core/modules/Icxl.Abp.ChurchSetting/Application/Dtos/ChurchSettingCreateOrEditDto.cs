using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace Icxl.Abp.ChurchSetting.Application.Dtos
{
    public class ChurchSettingCreateOrEditDto:EntityDto<Guid>
    {
        [Required] public string ChurchSettingName { get; set; }
        public bool Enable { get; set; }
        [Required] public string ProviderName { get; set; }
        public string ProviderKey { get; set; }
        public List<ChurchSettingNodeCreateOrEditDto> ChurchSettingNodes { get; set; }
    }
}