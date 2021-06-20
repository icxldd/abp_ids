using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;

namespace Icxl.Abp.ChurchSetting.Domain
{
    public class ChurchSettingNode : CreationAuditedEntity<Guid>
    {
        public string Desc { get; set; }
        public string Value { get; set; }
        public Guid ChurchSettingId { get; set; }
        [ForeignKey("ChurchSettingId")] public virtual ChurchSetting ChurchSetting { get; set; }
    }
}