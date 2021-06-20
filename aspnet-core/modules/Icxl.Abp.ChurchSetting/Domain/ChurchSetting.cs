using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities.Auditing;

namespace Icxl.Abp.ChurchSetting.Domain
{
    public class ChurchSetting : FullAuditedAggregateRoot<Guid>
    {
        protected ChurchSetting()
        {
        }

        public ChurchSetting(
            [NotNull] string churchSettingName,
            bool enable,
            [NotNull] string providerName,
            [CanBeNull] string providerKey,
            ICollection<ChurchSettingNode> churchSettingNodes = null)
        {
            ChurchSettingName = churchSettingName;
            Enable = enable;
            ProviderName = providerName;
            ProviderKey = providerKey;
            ChurchSettingNodes = churchSettingNodes ?? new List<ChurchSettingNode>();
        }

        [NotNull] public string ChurchSettingName { get; set; }

        public bool Enable { get; set; }

        [NotNull] public string ProviderName { get; set; }

        [CanBeNull] public string ProviderKey { get; set; }

        //一共有多少条    值
        public int NodesMaxIndex { get; set; }

        public virtual ICollection<ChurchSettingNode> ChurchSettingNodes { get; set; }
    }
}