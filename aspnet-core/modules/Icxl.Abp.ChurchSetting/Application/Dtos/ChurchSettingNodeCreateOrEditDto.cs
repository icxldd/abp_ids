using System;

namespace Icxl.Abp.ChurchSetting.Application.Dtos
{
    public class ChurchSettingNodeCreateOrEditDto
    {
        public Guid Id { get; set; }

        public string Desc { get; set; }

        public string Value { get; set; }

        public Guid ChurchSettingId { get; set; }
    }
}